using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] ground_tiles;
	public GameObject coin;

	public GameObject fence_hor;
	public GameObject fence_ver;
	public GameObject fence_edge;



	int LEVEL_WIDTH = 30;
	int LEVEL_HEIGHT = 30;

	int COIN_NUM = 100;


	void Start () {
		float groundScale;
		float fenceScale;
		groundScale = ground_tiles[0].GetComponent<Renderer>().bounds.size.y; // get the scale/size call it whatever you want
		fenceScale = fence_edge.GetComponent<Renderer>().bounds.size.y;
		//coinScale = coin.renderer.bounds.size.y;


		for (int x=0;x<LEVEL_WIDTH;x++){
			for (int y=0;y<LEVEL_HEIGHT;y++){

				int groundIndex = Random.Range(0, ground_tiles.Length);
				GameObject g = ground_tiles[groundIndex];
				float newX = (float)x*groundScale;
				float newY = (float)y*groundScale;

				if ((x==0)&&(y==0)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_edge, new Vector3(newX, newY), Quaternion.AngleAxis(90f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((x==LEVEL_WIDTH-1)&&(y==0)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_edge, new Vector3(newX, newY), Quaternion.AngleAxis(180f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((x==LEVEL_WIDTH-1)&&(y==LEVEL_WIDTH-1)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_edge, new Vector3(newX, newY), Quaternion.AngleAxis(270f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((x==0)&&(y==LEVEL_WIDTH-1)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_edge, new Vector3(newX, newY), Quaternion.AngleAxis(0f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((y==0)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_hor, new Vector3(newX, newY), Quaternion.AngleAxis(180f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((y==LEVEL_HEIGHT-1)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_hor, new Vector3(newX, newY), Quaternion.AngleAxis(	0f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((x==0)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_ver, new Vector3(newX, newY), Quaternion.AngleAxis(	0f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}else if ((x==LEVEL_WIDTH-1)){
					newX = (float)x*fenceScale;
					newY = (float)y*fenceScale;
					(Instantiate(fence_ver, new Vector3(newX, newY), Quaternion.AngleAxis(180f, Vector3.forward)) as GameObject).transform.parent = transform;
					continue;
				}
				(Instantiate(g, new Vector3(newX, newY), Quaternion.identity) as GameObject).transform.parent = transform;
			}
		}
		// coins
		for (int i=0;i<COIN_NUM;i++){
			float randX = (float)Random.Range(1,LEVEL_WIDTH-2)*groundScale;
			float randY = (float)Random.Range(1,LEVEL_HEIGHT-2)*groundScale;

			(Instantiate(coin,new Vector3(randX,randY),Quaternion.identity) as GameObject).transform.parent = transform;
		}
	}

}
