using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(CardHand))]
	public class PlayerTurnState : GameStateNode {
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "<color=blue>Your Turn</color>";
			
			this.hand = this.GetComponent<CardHand>();
			Debug.Log(this.hand);
			
			this.hand.cardClickCallback = (CardController cc) => {
				
				Debug.Log("Click called back to " + cc + "!");
				
				CardValue val = cc.cardType.Value;
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
					
					Debug.Log("Player fished card: " + fish);
					
				}
				
				this.next.Enter(this);
				
			};
			
		}
		
	}
	
}
