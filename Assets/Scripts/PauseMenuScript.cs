using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	
	private float wantedValue = 10;
	
	public bool visibleMenu = false;
	
	// Display the Pause Menu
	void OnGUI() {
		
		// if game is not pause, exit the function
		if(!visibleMenu)
			return;
		
		wantedValue = GUI.HorizontalScrollbar (new Rect (25, 25, 100, 30), wantedValue, 1.0f, 0.0f, 10.0f);
	}
	
	
	// Toggle the visibility of the Pause Menu
	public void ToggleVisibility() {
		visibleMenu ^= true;	// very fancy bits computations :)
	}
	
}
