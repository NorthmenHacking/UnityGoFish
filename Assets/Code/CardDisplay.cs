using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NorthmenGoFish.Unity {
	
	public class CardDisplay : MonoBehaviour {
		
		private Text suit;
		private Text value;
		private Text number;
		
		void Awake() {
			
			this.suit = this.transform.FindChild("Suit").GetComponent<Text>();
			this.value = this.transform.FindChild("Value").GetComponent<Text>();
			this.number = this.transform.FindChild("Number").GetComponent<Text>();
			
		}
		
		public void UpdateDisplay(CardType type) {
			
			this.suit.text = type.Suit.name;
			this.value.text = type.Value.name;
			this.number.text = char.ToString(type.Value.icon);
			
		}
		
	}
	
}
