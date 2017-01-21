using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float rotSpeed;


	private Rigidbody2D rb;

	public LayerMask ground;
	private bool isGrounded;
	private Collider2D col;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
		rb.AddForce (transform.up * jumpForce * 100);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		isGrounded = Physics2D.IsTouchingLayers (col, ground);

		rb.velocity = new Vector2 (speed, rb.velocity.y);
		if (isGrounded) {
			rb.velocity = new Vector2 (speed, 0);
			this.gameObject.transform.Rotate(0, 0, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		} else if (!isGrounded) {
			this.gameObject.transform.Rotate (0, 0, Time.deltaTime * rotSpeed);
		}

		if(Input.GetKey("space")){
			if(isGrounded){
				rb.AddForce (transform.up * jumpForce * 100);
			}
		}
			

	}

	void OnCollisionEnter(Collision collision){

	}
}
