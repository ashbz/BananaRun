using UnityEngine;
using System.Collections;

public class NumSprite : MonoBehaviour {
	
	public Sprite[] nums;
	int currNum;
	float temp;

	// Use this for initialization
	void Start () {
		currNum = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time<temp+1f){
			return;
		}
		temp = Time.time;
		if (currNum>2){
			currNum = 0;
		}

		GetComponent<SpriteRenderer>().sprite = nums[currNum];

		currNum++;

	}


}
