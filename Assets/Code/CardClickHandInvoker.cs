using UnityEngine;
using System;
using System.Collections;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(CardController))]
	public class CardClickHandInvoker : MonoBehaviour {
		
		private CardController cc;
		
		void Start() {
			this.cc = this.GetComponent<CardController>();
		}
		
		void OnMouseDown() {
			
			Action<CardController> callback = cc.hand.cardClickCallback;
			
			if (callback != null) {
				callback.Invoke(this.cc);
			}
			
		}
		
	}
	
}
