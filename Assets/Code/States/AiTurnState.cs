using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	public class AiTurnState : GameStateNode {
		
		public float secondsToPick;
		public float secondsToExit;
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "<color=red>A.\"I.\" Turn</color>";
			
			this.hand = this.GetComponent<CardHand>();
			Debug.Log(this.hand);
			
			this.StartCoroutine(this.PickPattern());
			
		}
		
		private IEnumerator PickPattern() {
			
			yield return new WaitForSeconds(this.secondsToPick);
			
			CardController picked = this.hand.cards[Random.Range(0, this.hand.cards.Count)];
			CardValue val = picked.cardType.Value;
			List<CardController> opponentMatches = this.opponent.GetCardsOfValue(val);
			
			if (opponentMatches.Count > 0) {
				
				// Take the cards.
				opponentMatches.ForEach(match => {
					
					this.opponent.RemoveCard(match);
					this.hand.AddCard(match);
					
				});
				
				this.hand.Simplify();
				
			} else {
				
				// Or "go fish".
				CardController fish = this.dealer.DealOneOff();
				this.hand.AddCard(fish);
				
				Debug.Log("AI Fished card: " + fish);
				
			}
			
			yield return new WaitForSeconds(this.secondsToExit);
			
			this.next.Enter(this);
			
		}
		
	}
	
}
