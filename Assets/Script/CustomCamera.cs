using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    public float allowedDistance;
    public float speed;
    public float height;
    public float rotationSpeed;
    public float zoomSpeed;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, targetTransform.position.y + height, transform.position.z);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        follow();

        transform.LookAt(targetTransform);

        if (Input.GetKey(KeyCode.J)){
            rotate(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.K)){
            rotate(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Y) && allowedDistance < 25){
            allowedDistance = allowedDistance + zoomSpeed * Time.deltaTime; 
            zoom(zoomSpeed);
        }
        else if (Input.GetKey(KeyCode.H) && allowedDistance > 2){
            allowedDistance = allowedDistance - zoomSpeed * Time.deltaTime; 
        }
    }

    public void follow(){
        
        Vector3 targetPosition = targetTransform.position;

        float distance = Vector3.Distance (transform.position, targetPosition);

        if (distance > allowedDistance){

            Vector3 movement = Vector3.forward * speed * Time.deltaTime;
            //movement.y = 0;
            transform.Translate(movement);

            transform.position = new Vector3(transform.position.x, targetTransform.position.y + height, transform.position.z);
        }
    }

    public void rotate(float value){
        transform.Translate(Vector3.right * value * Time.deltaTime);
    }


    public void zoom(float value){
        Vector3 movement = Vector3.back * value * Time.deltaTime;
        //movement.y = 0;
        transform.Translate(movement);

        transform.position = new Vector3(transform.position.x, targetTransform.position.y + height, transform.position.z);

    }
}
