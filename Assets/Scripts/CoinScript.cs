using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	Animator anim;
	public float DEFAULT_SPEED = 8f;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		anim.speed = DEFAULT_SPEED*Time.fixedDeltaTime*GetComponent<Rigidbody2D>().velocity.magnitude;
		//Debug.Log(rigidbody2D.velocity.magnitude);
	}
}
