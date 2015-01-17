using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Character))]
public class Movement : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
	private Character c;
	private CharacterController controller;

	void Awake(){
		c = GetComponent<Character>();
        controller = GetComponent<CharacterController>();

        speed = c.currentStats.movSpd;
	}
    
    void Update() {
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
