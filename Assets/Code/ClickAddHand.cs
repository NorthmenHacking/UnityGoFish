using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardController))]
public class ClickAddHand : MonoBehaviour {

	public CardHand targetHand;

	void OnMouseDown() {

		CardController cc = this.GetComponent<CardController>();

		if (cc.hand == null) {
			this.targetHand.AddCard(cc);
		} else {
			this.targetHand.RemoveCard(cc);
		}

	}

}
