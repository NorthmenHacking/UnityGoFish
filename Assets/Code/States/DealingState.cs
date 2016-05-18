using UnityEngine;
using System.Collections;

namespace NorthmenGoFish.Unity {
	
	[RequireComponent(typeof(Dealer))]
	public class DealingState : StateNode {
		
		private Dealer dealer;
		
		protected override void Setup() {

			this.dealer = this.GetComponent<Dealer>();

		}
		
		protected override void OnEnter(StateNode prev) {
			
			TurnSelector.INSTANCE.Text = "Dealing cards...";
			
			this.dealer.enabled = true;
			
			this.dealer.StartDealing(() => {
				this.next.Enter(this); // Just move on to the next state asap.
			});
			
		}
		
	}
	
}
