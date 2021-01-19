using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 delayedPlayerPosition;
    public Vector3 target;
    public float speed;
    public float turnSpeed;

    public float isStalkingTime;
    public float isLoiterTime;

    public float updateStalkingPositionCounter;

    // Start is called before the first frame update
    void Start()
    {
        updateStalkingPositionCounter = 0;
        speed = 0.6f;
        turnSpeed = 0.6f;
        isStalkingTime = 0;
        isLoiterTime = 0;

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            player = gameObject;
        }

        delayedPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update(){     

        updateStalkingPositionCounter+= 1 * Time.deltaTime;
        isLoiterTime += 1 * Time.deltaTime; 
        isStalkingTime += 1 * Time.deltaTime; 

        if (updateStalkingPositionCounter > 2){
            updateStalkingPositionCounter = 0;

            delayedPlayerPosition = player.transform.position;

        }

        if (isStalkingTime < 6){
            stalk();
            
        }else if(isLoiterTime < 6){
            loiter();
        }
        else{
            isStalkingTime = 0;
            isLoiterTime = 0;

            target = new Vector3(transform.position.x + Random.Range(-25, 26), transform.position.y, transform.position.z + Random.Range(-25, 26));
  
        }
    }

    private void loiter(){
        isLoiterTime += 1* Time.deltaTime;
        GoTowards(target, transform.position, speed, turnSpeed);
    }

    private void stalk(){
        isStalkingTime += 1* Time.deltaTime;
        GoTowards(delayedPlayerPosition, transform.position, speed, turnSpeed);
    }

    private void GoTowards(Vector3 target, Vector3 position, float speed, float turnSpeed){
        var q = Quaternion.LookRotation(target - position);
        
        q.x = 0f;
        q.z = 0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, q, turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
