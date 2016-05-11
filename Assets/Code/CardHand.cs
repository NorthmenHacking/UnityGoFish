using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardHand : MonoBehaviour {

	public List<CardController> cards = new List<CardController>();
	public Transform target;
	public Transform discardTransform;

	public float cardSpacing;

	void Start () {
		
		foreach (CardController cc in cards) {
			cc.SetHand(this);
		}

	}

	void Update () {
	
	}

	public Vector3 GetCardPosition(CardController cc) {

		if (!this.cards.Contains (cc)) return Vector3.zero;
		int index = this.cards.FindIndex(o => cc == o);

		Vector3 increment = this.transform.right * this.cardSpacing;
		Vector3 minPos = this.transform.position - (increment * ((this.cards.Count - 1F) / 2F));

		return minPos + (increment * index);

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
