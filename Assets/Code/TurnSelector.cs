using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnSelector : MonoBehaviour {

	public static TurnSelector INSTANCE;

	private Text text;

	void Awake() {

		this.text = this.GetComponent<Text>();

		INSTANCE = this;

	}

	public string Text {

		set {
			this.text.text = value;
		}

		get {
			return this.text.text;
		}

	}

}
