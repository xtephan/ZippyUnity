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
	
		transform.position = character.transform.position - (rotation * offset);
		
		transform.LookAt(character.transform);
		
//		// Compute what we want
//		float currentAngle = transform.eulerAngles.y;
//        float desiredAngle = character.transform.eulerAngles.y;
//        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
//        Quaternion rotation = Quaternion.Euler(0, angle, 0);
//		
//		// And do it :D
//        transform.position = character.transform.position - (rotation * offset);
//        transform.LookAt(character.transform);
		
	}
	
	
}
