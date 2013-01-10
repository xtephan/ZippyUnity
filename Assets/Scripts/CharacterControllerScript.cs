using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public float turningSpeed = 60;
    
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 oldPosition = Vector3.zero;
	
	//Kinetic Data
	public HandIisuInput HandInput1;
	public GameObject HandViz1;
    public GameObject HandViz2;
	
	//Should the Character Move Forward?
	private float getForwardMovement() {
		
		// Palms la 0 grade
		if( PlayerPrefs.GetFloat("RY") < 210 )
			return 0;
		
		// Palma la 180 de grade
		if( PlayerPrefs.GetFloat("RY") > 220 && PlayerPrefs.GetFloat("RY") < 240 )
			return 0.65f;
		
		
		return 0;
	}
	
	
	
	void Update() {
		
		
		
		if(HandInput1.Detected)
		{
			HandData data = HandInput1.HandPositions;
			
			//Vector3 localPosition = new Vector3(data.PalmPosition.x, data.PalmPosition.y, data.PalmPosition.z);
			
			//Debug.Log("---" + data.PointingDirection);
			
			//setPalm(data);
			
			//Debug.Log(_palm.transform.rotation.x.ToString("F") + " xxx " + _palm.transform.rotation.y.ToString("F") + " xxx " + _palm.transform.rotation.z.ToString("F"));
		}
        
		CharacterController controller = GetComponent<CharacterController>();
		
		//Moving forward
		float forwardMove=getForwardMovement();
		//Debug.Log(PlayerPrefs.GetFloat("RX").ToString("F")  + " xxx " + PlayerPrefs.GetFloat("RY").ToString("F") + " xxx " + PlayerPrefs.GetFloat("RZ").ToString("F"));
		Debug.Log(PlayerPrefs.GetFloat("RY") + "--" + forwardMove);
        
		if (controller.isGrounded) {
            
			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, getForwardMovement());
			moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
			
			
			// Rotation
			float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
			transform.Rotate(0, horizontal, 0);
			
            
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
		
	
		if(transform.position != oldPosition)
			transform.animation.Play();
		else {
			transform.animation.Stop();
		}
	
		oldPosition = transform.position;
    }


}