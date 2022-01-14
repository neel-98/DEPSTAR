using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    // Start is called before the first frame update
     public float mouse_speed = 50.0f;
     public float movement_speed = 30.0f;
     public float jump =100f;
     public float gravityFactor = 1.0f;
     public TextMesh txt;
     
    CharacterController cc;
    Camera camera;
    float vertical_limit = 60.0f;
    float vertical_rotation = 0;
    Vector3 movement;

    void Start()
    {
         cc = GetComponent<CharacterController>();
         camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //For Movement in PC

    	   float left_right_rot = Input.GetAxis("Mouse X") * mouse_speed;
    	   float up_down_rot = Input.GetAxis("Mouse Y") * mouse_speed;
    	   float deltaX = Input.GetAxis( "Horizontal" ) * movement_speed;
           float deltaZ = Input.GetAxis( "Vertical" ) * movement_speed;
         
         //rotate a player left-right
         transform.Rotate(new Vector3(0, left_right_rot * mouse_speed, 0) * Time.deltaTime , Space.World);

         //rotate a player up-down
         vertical_rotation -= up_down_rot;
         vertical_rotation = Mathf.Clamp(vertical_rotation,-vertical_limit,vertical_limit);
         Camera.main.transform.localRotation = Quaternion.Euler(vertical_rotation,0,0);  
         
         //move a player
        
        movement = new Vector3( deltaX, Physics.gravity.y * gravityFactor, deltaZ );
        
        
        if(cc.isGrounded && Input.GetKeyDown(KeyCode.Space)){
            movement.y = jump;
        }
         movement = transform.rotation * movement;
         cc.Move( movement * Time.deltaTime);


        //For Movement in VR	
/*    	float deltaX = Input.GetAxis( "Horizontal" ) * movement_speed;
    	float deltaZ = Input.GetAxis( "Vertical" ) * movement_speed;
        Vector3 ford = camera.transform.forward;
        Vector3 righ = camera.transform.right;
        Vector3 mov = -ford*deltaX + righ*deltaZ;
        mov = new Vector3(mov.x,Physics.gravity.y * gravityFactor, mov.z);
    	
        if(cc.isGrounded && Input.GetKeyDown(KeyCode.JoystickButton5)){
            mov.y = jump;
        }
    	cc.Move( mov * Time.deltaTime);
*/
    }
}
