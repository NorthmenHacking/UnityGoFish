using UnityEngine;
using System.Collections;

public class ClickScene : MonoBehaviour {

	public void DoTransfer(string scene) {
		Application.LoadLevel(scene);
	}
	
}
