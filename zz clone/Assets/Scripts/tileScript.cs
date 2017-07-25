using UnityEngine;
using System.Collections;

public class tileScript : MonoBehaviour {
	// Use this for initialization
	private float fallDelay=1;
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag== "Player") 
		{
			TileManager.Instance.SpawnTiles();
			StartCoroutine(fallDown());
		}
	}
	IEnumerator fallDown(){
		yield return new WaitForSeconds(fallDelay);
		GetComponent<Rigidbody>().isKinematic=false;
		yield return new WaitForSeconds (2);
		switch(gameObject.name){
		case "leftTiles":
			TileManager.Instance.LeftTiles.Push(gameObject);
			gameObject.GetComponent<Rigidbody>().isKinematic=true;
			gameObject.SetActive(false);
				break;
		case "topTiles":
			TileManager.Instance.LeftTiles.Push(gameObject);
			gameObject.GetComponent<Rigidbody>().isKinematic=true;
			gameObject.SetActive(false);
				break;
		}
	}
}
