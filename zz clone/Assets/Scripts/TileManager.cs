using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TileManager : MonoBehaviour {
	public GameObject[] tilePrefabs;
	public GameObject currentTile;
	private static TileManager instance;
	private Stack<GameObject> leftTiles=new Stack<GameObject>();

	public Stack<GameObject> LeftTiles {
		get {
			return leftTiles;
		}
		set{ leftTiles = value;}
	}

	private Stack<GameObject> topTiles=new Stack<GameObject>();

	public Stack<GameObject> TopTiles {
		get {
			return topTiles;
		}
		set{ topTiles = value;}
	}

	public static TileManager Instance {
		get 
		{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<TileManager>();
			}
			{
				return instance;
			}
		}
	}
	// Use this for initialization
	void Start () {
		createTiles (100);
		for (int i=0; i<20; i++) {
			SpawnTiles ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void createTiles(int amount){
		for (int i=0; i<amount; i++) {
			leftTiles.Push(Instantiate(tilePrefabs [0]));
			topTiles.Push (Instantiate (tilePrefabs [1]));
			topTiles.Peek().name="topTiles";
			topTiles.Peek ().SetActive (false);
			leftTiles.Peek().name="leftTiles";
			leftTiles.Peek ().SetActive (false);
		}
	}
	public void SpawnTiles()
	{
		if (leftTiles.Count == 0 || topTiles.Count == 0) {
			createTiles (20);
		}

		int randomIndex = Random.Range (0, 2);
		if (randomIndex == 0) {
			GameObject tmp = leftTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile=tmp;
		}
		else if (randomIndex == 1) {
			GameObject tmp = topTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile=tmp;
		}
		int spawnPickup = Random.Range (0, 10);
		if(spawnPickup==0){
			currentTile.transform.GetChild(1).gameObject.SetActive(true);
		}
		//currentTile=(GameObject)Instantiate (tilePrefabs[randomIndex], currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position, Quaternion.identity);
	}
	public void resetGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}