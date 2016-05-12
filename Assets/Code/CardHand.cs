using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardHand : MonoBehaviour {

	public List<CardController> cards = new List<CardController>();
	public Transform target;

	public float cardSpacing;

	void Start () {
		
		foreach (CardController cc in cards) {
			cc.SetHand(this);
		}

	}

	void Update () {
	
	}

	public void AddCard(CardController card) {

		this.cards.Add(card);
		card.SetHand(this);

	}

}
