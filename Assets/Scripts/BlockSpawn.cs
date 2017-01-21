using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour {

	public GameObject whatToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) {

			//Debug.Log("mouse x: " + Input.mousePosition.x + "mouse y: " + Input.mousePosition.y);


			//Instantiate (whatToSpawn, new Vector2(coorX, coorY), Quaternion.identity);

			Camera camera = GetComponent<Camera>();
			Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));

			p.x = Mathf.RoundToInt (p.x);
			p.y = Mathf.RoundToInt (p.y);

			Instantiate (whatToSpawn, p, Quaternion.identity);

		}
	}

	//public void OnMouseUpAsButton() {

	//	Instantiate (whatToSpawn, transform.position, Quaternion.identity);
	//}
}
