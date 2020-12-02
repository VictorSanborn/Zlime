using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    GameObject focus;
    public float allowedDistance;
    public float speed;

    public float height;

    // Start is called before the first frame update
    void Start()
    {
        focus = GameObject.FindGameObjectWithTag("Player");

        transform.position = new Vector3(transform.position.x,height,transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        follow();

        transform.LookAt(focus.transform);
    }

    public void follow(){

        
        Vector3 targetPosition = focus.transform.position;

        float distance = Vector3.Distance (transform.position, targetPosition);

        if (distance > allowedDistance){

            Vector3 movement = Vector3.forward * speed * Time.deltaTime;
            //movement.y = 0;
            transform.Translate(movement);

            transform.position = new Vector3(transform.position.x,height,transform.position.z);
        }
    }
}
