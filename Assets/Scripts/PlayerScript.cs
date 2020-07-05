using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerScript : MonoBehaviour {

	public float speed = 10f;
	const float defaultCameraSize = 10f;
	public GameObject player;
	public AudioClip coinSound;
	public GameObject bullet;
	public GameObject bulletContainer;

	float shootSpeed = 0.05f;
	float lastShot;
	


	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(8,9);
		Physics2D.IgnoreLayerCollision(8,8);
		for(int i=0;i<100;i++){
			float x = Random.Range(-10000f,-1300f);
			float y = Random.Range(-10000f,-1300f);
			GameObject g;
			g = Instantiate(bullet, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
			g.transform.parent = bulletContainer.transform;
			BulletPool.addBullet(g);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		debugLine();
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		bool leftMouseDown = Input.GetMouseButton(0);
		bool rightMouseDown = Input.GetMouseButton(1);
		if (rightMouseDown){
			AttractCoins();
		}else if (leftMouseDown){
			if (Time.time>lastShot + shootSpeed){
				lastShot = Time.time;
				Shoot(100f);
			}
        }

		Vector2 newPos = GetComponent<Rigidbody2D>().position;
		newPos.x += hor*speed*Time.fixedDeltaTime;
		newPos.y += ver*speed*Time.fixedDeltaTime;
		//Debug.Log (hor);
		// rotation
		if (hor>0){
			Quaternion rot = player.transform.rotation;
			rot.y = Mathf.Lerp(rot.y,180f,5f);
			player.transform.rotation = rot;
		}
		if (hor<0){
			Quaternion rot = player.transform.rotation;
			rot.y = Mathf.Lerp(rot.y,0f,5f);
			player.transform.rotation = rot;
		}


		//cameraZoom = transform.rigidbody.velocity.magnitude;
		Globals.cameraZoom = (newPos - GetComponent<Rigidbody2D>().position).magnitude / Time.fixedDeltaTime / 20;
		Camera.main.orthographicSize = Globals.cameraZoom + defaultCameraSize;

		//rigidbody2D.MovePosition(newPos);
		//Debug.Log (newPos);
		//Debug.Log (newPos.normalized);
		GetComponent<Rigidbody2D>().AddForce((newPos-GetComponent<Rigidbody2D>().position)*1000f);
		//transform.position = newPos;

	}
	
	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "fence"){
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}else if (coll.gameObject.tag == "coin"){
			//AudioSource.PlayClipAtPoint(coinSound, coll.gameObject.rigidbody2D.position);
			GetComponent<AudioSource>().PlayOneShot(coinSound);
            //GameObject g = coll.gameObject;
            //Vector2 temp = - (transform.position - g.transform.position);
            //g.GetComponent<Rigidbody2D>().AddForce(temp*1000f);
            //DestroyObject(coll.gameObject);
            Globals.IncreaseHits();
			//Debug.Log (Globals.HITS);
		}
		
	}

	void AttractCoins(){
		GameObject[] coins;
		coins = GameObject.FindGameObjectsWithTag("coin");

		foreach (GameObject g in coins) {
			Vector2 temp = transform.position-g.transform.position;
			g.GetComponent<Rigidbody2D>().AddForce(temp);
		}
	}

	void Shoot(float speed){

		GameObject g2 = BulletPool.getBullet();//bullets[0];
		if (g2==null){
			//Debug.Log ("well shit");
			return;
		}

		Vector3 temp = Input.mousePosition;
		temp.z = 0f;
		Ray ray = Camera.main.ScreenPointToRay(temp);
		temp = ray.origin;
//		temp = Vector3.
		g2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		g2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
		g2.transform.position = player.transform.position;
//		g2.transform.LookAt(temp);
//		g2.rigidbody2D.AddForce(g2.transform.up*1000f);
		Vector3 finalTemp = ray.origin-player.transform.position;
		finalTemp.z = 0f;
		//*10000f);
		//g2.rigidbody2D.AddForce((finalTemp.normalized)*(10000f));//+rigidbody2D.velocity.magnitude*10000f));

		g2.GetComponent<Rigidbody2D>().AddForce(((Vector2)finalTemp.normalized)*(10000f) + (GetComponent<Rigidbody2D>().velocity*1000f));//+rigidbody2D.velocity.magnitude*10000f))
	}

	void debugLine(){
//		Vector3 temp = Input.mousePosition;
//		temp.z = 0f;
//		Ray ray = Camera.main.ScreenPointToRay(temp);
//		temp = ray.origin;
//		temp.z = 0f;
		//Debug.Log (rigidbody2D.velocity.magnitude);
//		Vector2 haha = new Vector2(temp.x,temp.y);
//		Debug.DrawLine(player.transform.position, temp, Color.red);//,1f,true);
		//Debug.Log (rigidbody2D.velocity);
		//Debug.Log (rigidbody2D.velocity);
	}
}
