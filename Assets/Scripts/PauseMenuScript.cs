using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	
	private float wantedWalkingValue = 10;
	private float wantedTurningValue = 30;
	
	public bool visibleMenu = false;
	
	public GameObject TurningSensitivityValueText, WalkingSensitivityValueText;
	
	// Display the Pause Menu
	void OnGUI() {
		
		// if game is not pause, exit the function
//		if(!visibleMenu)
//			return;
		//tmpRect = new Rect (25, 25, 100, 30);
		//GUI.TextArea( tmpRect,"Walking Sensitivity: " );
		
		// Create the slide bar
		wantedWalkingValue = GUI.HorizontalScrollbar (new Rect (360, 76, 250, 30), wantedWalkingValue, 1.0f, 0.0f, 60.0f);
		wantedTurningValue = GUI.HorizontalScrollbar (new Rect (360, 116, 250, 30), wantedTurningValue, 1.0f, 0.0f, 60.0f);
	
		// Update the Displayed Values
		TurningSensitivityValueText.guiText.text = Mathf.Round(wantedTurningValue).ToString();
		WalkingSensitivityValueText.guiText.text = Mathf.Round(wantedWalkingValue).ToString();
	
		
		// Buttons
		if (GUI.Button(new Rect(235, 150, 70, 30), "CANCEL"))
        	Debug.Log("Clicked the CANCEL with an image");
		
		if (GUI.Button(new Rect(565, 150, 70, 30), "SAVE"))
        	Debug.Log("Clicked the SAVE with an image");
		
	}
	

	
	
	// Toggle the visibility of the Pause Menu
	public void ToggleVisibility() {
		visibleMenu ^= true;	// very fancy bits computations :)
		
		//TODO: disable or enable the texts
	}
	
}
