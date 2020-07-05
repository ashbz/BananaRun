using UnityEngine;
using System.Collections.Generic;

public static class BulletPool
{
	public static List<GameObject> bullets = new List<GameObject>();
	

	public static void addBullet(GameObject g){
		g.GetComponent<Collider2D>().enabled = false;
		bullets.Add(g);
	}

	public static GameObject getBullet(){
		if (count()>0){
			GameObject g = bullets[0];
			bullets.RemoveAt(0);
			//bullets.Add(g);
			g.SetActive(true);
			g.GetComponent<Collider2D>().enabled = true;
			return g;
		}else{
			//Debug.Log("no bullet available");
			return null;
		}
	}

	public static void deleteBullet(GameObject g){
		g.GetComponent<Collider2D>().enabled = false;
//		Debug.Log ("Added!");
		addBullet(g);
		//bullets.Add(g);
		g.SetActive(false);
//		Debug.Log ("Deleted!");
//		Debug.Log ("Count: " + count().ToString());

	}

	public static int count(){
		return bullets.Count;
	}

	public static void clearPool(){
		bullets.Clear();
	}

}


