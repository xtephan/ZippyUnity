using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public float turningSpeed = 60;
    
	private Vector3 moveDirection = Vector3.zero;
    
	void Update() {
        
		CharacterController controller = GetComponent<CharacterController>();
        
		if (controller.isGrounded) {
            
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
			// Rotation
			float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
			transform.Rotate(0, horizontal, 0);
			
            
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
	
//		if(transform.position != oldPosition)
//			transform.animation.Play();
//		else {
//			transform.animation.Stop();
//		}
//	
//		oldPosition = transform.position;
    }


}