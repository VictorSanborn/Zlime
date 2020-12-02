using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int turnSpeed;
    public float speed;
    public Vector3 rotation;
    public float velocity;
    private Vector3 Target;
    private float target;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){     
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        if(moveHorizontal != 0 || moveVertical != 0){
            CalcRotation(moveHorizontal, moveVertical);
                    
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
         
        }

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
}
