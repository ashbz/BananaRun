using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	Camera c;

	float WIDTH;
	float HEIGHT;

	public Sprite[] nums;
	

	void Start () {
		c = GameObject.FindWithTag("UICamera").GetComponent<Camera>();

		WIDTH = c.pixelWidth;
		HEIGHT = c.pixelHeight;
		Vector2 topRight;
		topRight = new Vector2(WIDTH, HEIGHT);
		Vector3 temp = c.ScreenToWorldPoint(topRight);
		temp.z = 0;
		transform.position = temp;
	}	

	void FixedUpdate () {
		float tempWidth = c.pixelWidth;
		float tempHeight = c.pixelHeight;

		if ((tempWidth!=WIDTH) || (tempHeight!=HEIGHT)){
			//Debug.Log ("Resized");
			Start ();
		}
	}

	void updateBar(){

	}
}
