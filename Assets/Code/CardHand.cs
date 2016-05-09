using UnityEngine;
using System.Collections;

public class CardHand : MonoBehaviour {

	public CardController[] cards;
	public Transform target;
	
	void Start () {

		foreach (CardController cc in cards) {
			cc.SetHand(this);
		}

	}

	void Update () {
	
	}

}
