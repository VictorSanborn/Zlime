using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int turnSpeed;
    public float speed;
    public Vector3 rotation;
    public float jumpHeight;
    private Vector3 Target;
    private float target;
    private float angle;
    private Vector3 currentVelocity;
    private float jumpCooldown;
    private bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumpCooldown = 0;
    }

    // Update is called once per frame

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        if (isGrounded){
            if(Input.GetKey(KeyCode.Space)) CalcJump(rb.transform.forward);
            if(moveHorizontal != 0 || moveVertical != 0){ 
                CalcRotation(moveHorizontal, moveVertical); 
                Vector3 pos = rb.transform.position;
                rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);           
                currentVelocity =  rb.transform.position - pos;
            }
            else currentVelocity = new Vector3(0,0,0);
        }

        //GetComponent<Animator>().SetFloat("forwardSpeed", (Mathf.Abs(currentVelocity.x) + Mathf.Abs(currentVelocity.z)) * 200);
    }
    void OnCollisionStay(Collision col){ 
        if(col.contacts[0].normal.y >= 0.6f){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col){
        isGrounded = false;
    }

    public void CalcRotation(float moveH, float moveV){

        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        Quaternion camRotationFlattened = Quaternion.LookRotation(camForward);

        angle = Mathf.Atan2 (moveH, moveV) * Mathf.Rad2Deg; 

        if (true){
            Quaternion quaternionAngle = Quaternion.Euler (new Vector3 (0, angle, 0));
            Quaternion relativeRotation = camRotationFlattened * quaternionAngle;
            Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, relativeRotation, Time.deltaTime * turnSpeed);

            transform.rotation = lerpRotation;
        }            
            
    }

    public void CalcJump(Vector3 direction){
        jumpCooldown -= 1*Time.deltaTime;
        if (jumpCooldown <= 0){
            rb.AddForce(Vector3.up * 240);
            rb.AddForce(direction * (50 * speed));

            jumpCooldown = (float)0.10;
        }

    }
    
}
