using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(LerpTo))]
	public class CardController : MonoBehaviour {
		
		private Rigidbody rb;
		
		[System.NonSerialized]
		public CardHand hand;
		public CardType cardType;
		
		public float rotSpeed = 1F;
		public float moveSpeed = 5F;
		
		public float dealerDestroyThreshold = 0.025F;
		
		private CardDisplay display;
		
		[System.NonSerialized]
		public Dealer dealer;
		
		void Start () {
			
			this.rb = this.GetComponent<Rigidbody>();
			this.display = this.GetComponentInChildren<CardDisplay>();
			
		}
		
		void Update () {
			
			if (this.hand != null && this.rb != null) {
				
				// Position
				Vector3 targetPos = this.hand.GetCardPosition(this);
				this.transform.position = Vector3.Lerp(this.transform.position, targetPos, this.moveSpeed * Time.deltaTime);
				
				// Rotation
				Vector3 delta = this.hand.target.position - this.transform.position;
				Quaternion target = Quaternion.LookRotation(delta);
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, this.rotSpeed * Time.deltaTime);
				
			}
			
		}
		
		// Could be an attribute.
		public void SetHand(CardHand hand) {
			
			Debug.Log("Hand is now " + hand + " for " + this + "!");
			
			this.rb = this.GetComponent<Rigidbody>();
			
			this.hand = hand;
			this.rb.isKinematic = (hand != null);
			
		}
		
		// Could be an attribute.
		public void SetCardType(CardType type) {
			
			this.cardType = type;
			this.display.UpdateDisplay(this.cardType);
			
		}
		
		public void Discard() {
			
			this.hand.RemoveCard(this);
			this.hand = null;
			
			// Go to the dealer.
			LerpTo lt = this.GetComponent<LerpTo>();
			lt.Run(this.dealer.transform, true);
			
			// Disable colliders.
			Collider[] cols = this.GetComponents<Collider>();
			foreach (Collider col in cols) {
				col.enabled = false;
			}
			
			this.StartCoroutine(this.DestroySelf());
			
		}
		
		private IEnumerator DestroySelf() {
			
			float initialDistSq = (this.dealer.transform.position - this.transform.position).sqrMagnitude;
			
			while (true) {
				
				float magSq = (this.dealer.transform.position - this.transform.position).sqrMagnitude;
				
				this.transform.localScale = Vector3.one * (magSq / initialDistSq);
				
				// Just wait for the next fixed update.
				yield return new WaitForFixedUpdate();
				
				if (magSq <= Mathf.Pow(this.dealerDestroyThreshold, 2)) break;
				
			}
			
			// Feels sad when writing this code, like the end to Soylent Green, somehow.
			this.dealer.AddCardToBottom(this);
			
		}
		
	}
	
}
