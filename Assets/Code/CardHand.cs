using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	public class CardHand : MonoBehaviour {
		
		public List<CardController> cards = new List<CardController>();
		public Transform target;
		public Transform discardTransform;
		
		public float cardSpacing;
		public float backwardsSpacing;
		public float upSpacing;

		public int UniqueValues {

			get {

				List<CardValue> valsEncountered = new List<CardValue>();

				foreach (CardController cc in this.cards) {

					CardValue cv = cc.cardType.Value;

					if (!valsEncountered.Contains(cv)) {
						valsEncountered.Add(cv);
					}

				}

				return valsEncountered.Count;

			}

		}

		void Start () {
			
			foreach (CardController cc in cards) {
				cc.SetHand(this);
			}
			
		}

		public Vector3 GetCardPosition(CardController cc) {
			
			if (!this.cards.Contains(cc)) return Vector3.zero;
			int sideIndex = this.GetCardValueIndex(cc.cardType.Value);
			int backIndex = this.GetPreviousCardsOfValueInDeck(cc.cardType);
			
			Vector3 sideIncrement = this.transform.right * this.cardSpacing;
			Vector3 backwardsIncrement = (this.transform.forward * this.backwardsSpacing) + (this.transform.up * this.upSpacing);
			Vector3 minPos = this.transform.position - (sideIncrement * ((this.UniqueValues - 1F) / 2F));
			
			return minPos + (sideIncrement * sideIndex) + (backwardsIncrement * backIndex);
			
		}

		private int GetCardValueIndex(CardValue val) {

			List<CardValue> valsEncountered = new List<CardValue>();

			foreach (CardController cc in this.cards) {

				CardValue cv = cc.cardType.Value;

				if (cv == val) {
					return valsEncountered.Count;
				} else {

					// Add it to the list.
					if (!valsEncountered.Contains(cv)) {
						valsEncountered.Add(cv);
					}

				}

			}

			return -1;

		}

		private int GetPreviousCardsOfValueInDeck(CardType type) {

			int cards = 0;

			foreach (CardController cc in this.cards) {

				if (cc.cardType == type) {
					return cards;
				} else if (cc.cardType.Value == type.Value) {
					cards++;
				}

			}

			return -1;

		}

		public void AddCard(CardController card) {
			
			this.cards.Add(card);
			card.SetHand(this);
			
		}
		
		public void RemoveCard(CardController card) {
			
			this.cards.Remove(card);
			card.SetHand(null);
			
			LerpTo lt = card.GetComponent<LerpTo>();
			lt.Run(this.discardTransform, false);
			
		}
		
	}
	
}
