using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(CardHand))]
	public class PlayerTurnState : GameStateNode {
		
		public float secondsToDeliver;
		public float secondsToFishing;
		public float secondsToExit;
		
		private CardController picked;
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "<color=blue>Your Turn</color>";
			
			this.hand = this.GetComponent<CardHand>();
			Debug.Log(this.hand);
			
			this.hand.cardClickCallback = (CardController cc) => {
				
				Debug.Log("Click called back to " + cc + "!");
				this.hand.cardClickCallback = null;
				
				this.picked = cc;
				this.StartCoroutine(this.DrawPattern());
				
			};
			
		}
		
		private IEnumerator DrawPattern() {
			
			CardValue val = this.picked.cardType.Value;
			List<CardController> opponentMatches = this.opponent.GetCardsOfValue(val);
			
			if (opponentMatches.Count > 0) {
				
				TurnSelector.INSTANCE.Text = "(" + val.name + "s?): <i>Yes, " + opponentMatches.Count + ".</i>";
				
				// Take the cards.
				opponentMatches.ForEach(match => {
					
					this.opponent.RemoveCard(match);
					this.hand.AddCard(match);
					
				});
				
			} else {
				
				TurnSelector.INSTANCE.Text = "(" + val.name + "s?): <i>Nope, go fish!</i>";
				
				// Or "go fish".
				yield return new WaitForSeconds(this.secondsToFishing);
				CardController fish = this.dealer.DealOneOff();
				this.hand.AddCard(fish);
				
				Debug.Log("Player fished card: " + fish);
				
			}
			
			yield return new WaitForSeconds(this.secondsToDeliver);
			
			this.hand.Simplify();
			yield return new WaitForSeconds(this.secondsToExit);
			
			// Win!
			if (this.hand.cards.Count == 0) {
				Application.LoadLevel(this.winSceneName);
			}
			
			this.next.Enter(this);
			
		}
		
	}
	
}
