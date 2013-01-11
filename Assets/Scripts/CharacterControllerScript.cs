using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public float turningSpeed = 60;
    
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 oldPosition = Vector3.zero;
	
	
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
	
	//Should the Character rotate?
	private float getHorizontalMovement() {
		
		// Palms la 90 grade
		if( PlayerPrefs.GetFloat("LY") > 250 && PlayerPrefs.GetFloat("LY") < 270 )
			return 0;
		
		// Palma la 0 de grade
		if( PlayerPrefs.GetFloat("LY") > 150 && PlayerPrefs.GetFloat("LY") < 190 )
			return 0.65f;
		
		// Palma la 180 de grade
		if( PlayerPrefs.GetFloat("LY") > 270 && PlayerPrefs.GetFloat("LY") < 290 )
			return -0.65f;
		
				// Palma la 180 de grade
		if( PlayerPrefs.GetFloat("LY") > 120 && PlayerPrefs.GetFloat("LY") < 140 )
			return -0.65f;
		
		return 0;
	}
	
	
	
	void Update() {
		
        
		CharacterController controller = GetComponent<CharacterController>();
		
		//Moving vectors
		float forwardMove    = getForwardMovement();
		float horizontalMove = getHorizontalMovement();
		
		//Debug.Log(PlayerPrefs.GetFloat("RX").ToString("F")  + " xxx " + PlayerPrefs.GetFloat("RY").ToString("F") + " xxx " + PlayerPrefs.GetFloat("RZ").ToString("F"));
		
		//Debug values
		Debug.Log("RY EulerAngle=" + PlayerPrefs.GetFloat("RY") + "--" + forwardMove);
        Debug.Log("LY EulerAngle=" + PlayerPrefs.GetFloat("LY") + "--" + horizontalMove);
		
		
		if (controller.isGrounded) {
            
			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = new Vector3( horizontalMove, 0, getForwardMovement() );
			moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
			
			
			// Rotation
			//float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
			float horizontal = horizontalMove * turningSpeed * Time.deltaTime;
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