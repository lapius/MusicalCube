using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private Rigidbody2D rb;

	public LayerMask ground;
	private bool isGrounded;
	private Collider2D col;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		isGrounded = Physics2D.IsTouchingLayers (col, ground);

		rb.AddForce (transform.right * speed);
		if (isGrounded) {
			rb.velocity = new Vector2 (speed, 0);
		}

		if(Input.GetKey("space")){
			if(isGrounded){
				rb.AddForce (transform.up * jumpForce);
			}
		}

	}

	void OnCollisionEnter(Collision collision){

	}
}
