using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public int turnSpeed;
    public float speed;
    public Vector3 rotation;
    private Vector3 Target;
    private float target;
    private float angle;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update(){ 
        agent.updatePosition = true;
        agent.updateRotation = true;

        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        if(Input.GetKey(KeyCode.Space)) CalcJump();
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

    public void CalcJump(){
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.transform.position = new Vector3(agent.transform.position.x, transform.position.y, agent.transform.position.z);
        Debug.Log("desired_velocity: " + agent.desiredVelocity.ToString());
        Debug.Log("destination: " + agent.destination.ToString());
        transform.position += new Vector3(0,1* Time.deltaTime,0);
    }
    
}
