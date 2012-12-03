using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	
	//public vars
	public AudioClip FoodSound;
	public MainGameScript mainGame;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnControllerColliderHit(ControllerColliderHit hit){
		
		if( hit.transform.name == "FoodPrefab(Clone)" ) {
  			
			Debug.Log("Hiit");
			
			mainGame.NextFood(hit.gameObject);
			
			AudioSource.PlayClipAtPoint(FoodSound, hit.transform.position);
			
			//Destroy(hit.gameObject);

		} 
	}

}
