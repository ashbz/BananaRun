using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log (string.Format("hit: {0}", col.gameObject.tag));
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		BulletPool.deleteBullet(gameObject);
		//Debug.Log (BulletPool.count());
		//Destroy (gameObject);
		//Destroy(this);
	}
}
