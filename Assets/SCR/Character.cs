using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	public GameObject Cam;
	private CharacterController controler;
	private Vector3 movedirection;
	public float gravity = 20f;
	public float speed = 20;
	public float rotspeed = 2;

	void Start () {
		controler = GetComponent<CharacterController> ();
		movedirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (controler.isGrounded) {

			movedirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			movedirection = transform.TransformDirection (movedirection);
			movedirection *= speed;

			if (Input.GetKeyDown (KeyCode.Space)) {

				movedirection.y = speed;
			}
		} 
		else {

			movedirection = new Vector3 (0, movedirection.y, Input.GetAxis ("Vertical"));
			movedirection = transform.TransformDirection (movedirection);
			movedirection.x *= speed;
			movedirection.z *= speed;
		}
		transform.Rotate (0, Input.GetAxis ("Horizontal") * 2, 0);
		movedirection.y -= gravity * Time.deltaTime;
		controler.Move (movedirection * Time.deltaTime);
	}
}
