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
        speed = 5;
        turnSpeed = 5;
    }

    // Update is called once per frame
    void Update(){     
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        if(moveHorizontal != 0 || moveVertical != 0){
            angle = Mathf.Atan2 (moveHorizontal, moveVertical) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (new Vector3 (-90, angle, 0)), Time.deltaTime * turnSpeed);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            float fangle=Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),transform.rotation);
            var test = (angle > 0 ? angle : (2*Mathf.PI + angle)) * 360 / (2*Mathf.PI);
            Debug.Log(test + " : " + angle);
            transform.Translate (movement * speed  * Time.deltaTime, Space.World); //* turnSpeed -(transform.rotation / angle)
        }
    }
}
