using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	
	// Public vars
	public AudioClip FoodSound;
	public MainGameScript mainGame;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	
	// Detect Collision with food
	void OnControllerColliderHit(ControllerColliderHit hit){
		
		if( hit.transform.name == "FoodPrefab(Clone)" ) {
  					
			mainGame.NextFood(hit.gameObject);
			
			AudioSource.PlayClipAtPoint(FoodSound, hit.transform.position);
			
		} 
	}

}
