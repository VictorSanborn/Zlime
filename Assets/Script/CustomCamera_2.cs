using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera_2 : MonoBehaviour
{

    

    // Start is called before the first frame update
    
    void LateUpdate(){
        transform.position = target.position;
    }

}
