using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	
	// Public vars
	public AudioClip FoodSound;
	public MainGameScript mainGame;
	
	// Limits for moving the character
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Move the character
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
		
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
	
	}
	
	
	// Detect Collision with food
	void OnControllerColliderHit(ControllerColliderHit hit){
		
		if( hit.transform.name == "FoodPrefab(Clone)" ) {
  					
			mainGame.NextFood(hit.gameObject);
			
			AudioSource.PlayClipAtPoint(FoodSound, hit.transform.position);
			
		} 
	}

}
