using UnityEngine;
using System.Collections;

namespace NorthmenGoFish.Unity {
	
	public abstract class StateNode : MonoBehaviour {

		public bool isInitial = false;
		public StateNode next;

		void Awake() {

			this.enabled = isInitial;

		}

		void Start() {

			this.Setup();

			// Just call the OnEnter method if we're the first one in the chain.
			if (this.isInitial) {
				this.OnEnter(null);
			}

		}

		public void Enter(StateNode prev) {

			if (!this.enabled) {

				prev.OnExit(this);
				prev.enabled = false;
				this.enabled = true;
				this.OnEnter(prev);

			}

		}

		protected virtual void Setup() {

		}

		protected virtual void OnEnter(StateNode prev) {

		}

		protected virtual void OnExit(StateNode next) {

		}
		
	}
	
	[RequireComponent(typeof(CardController))]
	public abstract class GameStateNode : StateNode {
		
		public CardHand opponent;
		public Dealer dealer;
		
		protected CardHand hand;
		
	}
	
}
