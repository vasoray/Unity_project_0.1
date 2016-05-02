//PIZDEC!!!!!!!! YAKUIS!!!!
/*using UnityEngine;
using System.Collections;

public class playerMovements : MonoBehaviour {
   private float JUMP_FORCE = 10.0f;
   private bool isTouchingMap;
   public float speed;
   private Rigidbody rbPlayer;
   //TRY
  // private int rotationSpeed = 100;
  // private int jumpHeight = 8;

   void Start () {
       rbPlayer = GetComponent<Rigidbody>();

   }

   void FixedUpdate() {

       float moveHorizontal = Input.GetAxis("Turns");
       float moveVertical = Input.GetAxis("Forward");
       //float jump = Input.GetAxis("Jump");
       //TRY
       //float rotation = moveHorizontal * rotationSpeed;
       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       //Vector3 pJump = new Vector3(0.0f,jump,0.0f);
       rbPlayer.AddForce(movement* speed);
       //rbPlayer.AddForce(pJump*speed);
       if (Input.GetKeyUp(KeyCode.Space)) { jump(); }

       /*TRY TO ADD JUMP ACTION HERE
       if (Input.GetKeyDown("space")) {
           transform.Translate(Vector3.up * 80 * Time.deltaTime, Space.World);

       //ITS SOMETHING WITH GRAVITY I HAVE NO IDEA HOW ITS WORKS YET!!! DONT TOUCH IT!!!

       }


   public void jump()
   {
       rbPlayer.AddForce(Vector3.up*JUMP_FORCE);
       if (isTouchingMap) { rbPlayer.velocity += Vector3.up*JUMP_FORCE; }
   }


}*/
//ITS FUCKING CRAZY MAN NEXT SCRIPT START JUMPING BUT STOP MOVING!!! PLEASE DONT TOUCH ANYTHING YET!!!!
using UnityEngine;
using System.Collections;

public class playerMovements : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
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