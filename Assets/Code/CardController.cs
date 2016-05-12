using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

	private Rigidbody rb;

	[System.NonSerialized]
	public CardHand hand;

	public float rotSpeed = 1F;
	public float moveSpeed = 5F;

	void Start () {

		this.rb = this.GetComponent<Rigidbody>();

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

	public void SetHand(CardHand hand) {

		Debug.Log("Hand is now " + hand + " for " + this + "!");

		this.rb = this.GetComponent<Rigidbody> ();

		this.hand = hand;
		this.rb.isKinematic = (hand != null);

	}

}
