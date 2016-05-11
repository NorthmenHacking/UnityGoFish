using UnityEngine;
using System.Collections;

public class LerpTo : MonoBehaviour {

	public float threshold;
	public float speed;

	private Transform target;
	private Rigidbody rb;

	private bool prevKinematics;

	void Start() {

		this.rb = this.GetComponent<Rigidbody>();

		this.enabled = false;

	}

	void Update () {

		this.transform.position = Vector3.Lerp (this.transform.position, this.target.position, this.speed * Time.deltaTime);
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, this.target.rotation, this.speed * Time.deltaTime);

		if ((this.target.position - this.transform.position).sqrMagnitude <= Mathf.Pow (this.threshold, 2)) {

			this.rb.isKinematic = this.prevKinematics;
			this.enabled = false;

		}

	}

	public void Run(Transform trans) {

		this.enabled = true;
		this.target = trans;

		this.prevKinematics = this.rb.isKinematic;
		this.rb.isKinematic = true;

	}

	public void Run(Transform trans, bool endingKinematics) {

		this.Run(trans);
		this.prevKinematics = endingKinematics;

	}

}
