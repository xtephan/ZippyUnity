using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	
	//public objects
	public GameObject Food, Congrats;
	public CharacterController Zippy;
	public GameObject TimeElapsedText;
	public PauseMenuScript PauseMenu;
	
	//Food Position
	private int Score = 0;
	private float[,] FoodPos = new float[,]{ 	{ 125f, 31f, 169f }, 
										  		{ 141f, 31f, 184f }, 
												{ 195f, 31f, 152f }  };
	
	// Various Vars
	private int TimeElapsed = 0;
	private bool isPaused = false;
	
	
	Vector3 NextFoodPosition() {
		return new Vector3(FoodPos[Score,0], FoodPos[Score,1], FoodPos[Score,2]);	
	}
	
	
	public void NextFood(GameObject hitFoodObject) {
		
		Score++;
		
		//Load Final Screen
		if( Score == 3 ) {
			GameOver();
		} else {
			Destroy(hitFoodObject);
			DisplayFood();
		}
		
		
	}
	
	
	//Instanciate a food
	private void DisplayFood(){
		//Display first food
		Instantiate( Food, NextFoodPosition(), Quaternion.identity );
	}
	
	// Use this for initialization
	void Start () {
		
		InvokeRepeating("UpdateTime",1,1);
		DisplayFood();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		// If Escape is presed
		if( Input.GetKeyUp(KeyCode.Escape) ) {
		
			if( isPaused ) {
				isPaused = false;
				Time.timeScale = 1;
			} else { // If game is not Paused
				isPaused = true;
				Time.timeScale = 0;
			}
			
			PauseMenu.ToggleVisibility();

		}
		
	}
	
	// Update Time Ellapsed
	private void UpdateTime() {
		TimeElapsed++;
		TimeElapsedText.guiText.text = "Elapsed Time: " + TimeElapsed.ToString();
	}
	
	
	private void GameOver() {
		Instantiate( Congrats, Zippy.transform.position, Zippy.transform.rotation );
	}
	
	
}
