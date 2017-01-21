using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float rotSpeed;
	private Vector3 go;
	public GameObject cameraa;
	private Vector3 camPos;
	private float dist;

	private Rigidbody2D rb;

	public LayerMask ground;
	private bool isGrounded;
	private bool isJumped;
	private Collider2D col;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<Collider2D> ();
		isJumped = true;
		rb.AddForce (transform.up * jumpForce*100);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		dist = transform.position.x - camPos.x;
		cameraa.transform.position = new Vector3 (cameraa.transform.position.x + dist, cameraa.transform.position.y, cameraa.transform.position.z);
		camPos = cameraa.transform.position;

		isGrounded = Physics2D.IsTouchingLayers (col, ground);


		if (isGrounded) {

			dist = transform.position.y - camPos.y;
			cameraa.transform.position = new Vector3 (cameraa.transform.position.x, cameraa.transform.position.y + dist, cameraa.transform.position.z);
			camPos = cameraa.transform.position;

			rb.velocity = new Vector2 (speed, 0);
			//transform.Translate (speed/10, 0, 0);

			//this.gameObject.transform.Rotate(0, 0, 0);
			//transform.localRotation  = Quaternion.Euler(0,0,0);

			rb.rotation = 0;
			rb.freezeRotation = true;

		} else if (!isGrounded) {
			if (isJumped) {
				//this.gameObject.transform.Rotate (0, 0, Time.deltaTime * rotSpeed);
				rb.angularVelocity = rotSpeed;
			}
			rb.velocity = new Vector2 (speed, rb.velocity.y);
			//transform.Translate (speed/10, 0, 0);
		}

		if(Input.GetKey("space")){
			if(isGrounded){
				rb.freezeRotation = false;
				isJumped = true;
				rb.AddForce (transform.up * jumpForce * 100);
			}
		}

	}

}
