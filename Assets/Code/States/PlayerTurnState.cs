using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(CardHand))]
	public class PlayerTurnState : StateNode {
		
		public CardHand opponent;
		public Dealer dealer;
				
		private CardHand hand;
		
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
					// TODO Make the dealer draw the card.
					
				}
				
			};
			
		}
		
	}
	
}
