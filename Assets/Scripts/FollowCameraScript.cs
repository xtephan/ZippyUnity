using UnityEngine;
using System.Collections;

public class FollowCameraScript : MonoBehaviour {
	
	// Public Vars
	public GameObject character;
	public float damping = 1;
	
	
	Vector3 offset;
	
    
	void Start() {
        offset = character.transform.position - transform.position;
    }
	
	
	
	// Update is called once per frame
	void Update () {
	}
	
	
	// Using Late Update for better results :)
	void LateUpdate() {
		
    	float desiredAngle = character.transform.eulerAngles.y;
    	Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
	
		//transform.position = character.transform.position - (rotation * offset);
		
		//transform.LookAt(character.transform);
		transform.position = character.transform.position - rotation * offset;	
		//transform.eulerAngles = new Vector3( 350,31,0  );
		transform.LookAt(character.transform);
		transform.eulerAngles = new Vector3(360,transform.eulerAngles.y,0);
	}
	
	
}
