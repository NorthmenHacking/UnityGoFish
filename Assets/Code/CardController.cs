﻿using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

	private Rigidbody rb;
	private CardHand hand;

	public float rotSpeed = 1F;

	void Start () {

		this.rb = this.GetComponent<Rigidbody>();

	}

	void Update () {

		if (this.hand != null) {

			Vector3 delta = this.hand.target.position - this.transform.position;
			Quaternion target = Quaternion.LookRotation(delta);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, this.rotSpeed * Time.deltaTime);

		}

	}

	public void SetHand(CardHand hand) {

		Debug.Log("Hand is now " + hand + " for " + this + "!");

		this.hand = hand;
		this.rb.isKinematic = (hand != null);

		this.transform.SetParent(hand.transform);
		this.transform.position = hand.transform.position;

	}

}
