using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dealer : MonoBehaviour {

	public GameObject cardPrefab;
	public Transform spawnTransform;
	public List<CardHand> hands;

	public uint dealCycles = 1;
	public uint cardsPerDeal = 2;

	public float delayEachCard = 1F;

	private int cardsTotal;
	private int cardsDealt;

	void Start() {

		this.cardsTotal = (int) (this.dealCycles * this.cardsPerDeal * this.hands.Count);

		this.StartCoroutine("DealPattern");

	}

	void Update() {
	
	}

	private IEnumerator DealPattern() {

		for (int i = 0; i < this.dealCycles; i++) {

			foreach (CardHand ch in this.hands) {

				for (int j = 0; j < this.cardsPerDeal; j++) {

					GameObject card = (GameObject) GameObject.Instantiate(this.cardPrefab);

					card.transform.position = this.spawnTransform.position;
					card.transform.rotation = this.spawnTransform.rotation;

					yield return new WaitForSeconds(this.delayEachCard);
					ch.AddCard(card.GetComponent<CardController>());

					ClickAddHand cah = card.GetComponent<ClickAddHand>();
					cah.targetHand = ch;

					this.cardsDealt++;
					this.UpdateScale();

				}

			}

		}

		GameObject.Destroy(this.gameObject);

	}

	private void UpdateScale() {

		float percentage = ((float) (this.cardsTotal - this.cardsDealt)) / ((float) this.cardsTotal);
		this.transform.localScale = new Vector3 (1, percentage, 1);

	}

}
