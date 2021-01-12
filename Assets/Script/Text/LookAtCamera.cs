using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("MainCamera")[0];
    }

    void Update()
    {

        transform.LookAt(target.transform);
    }
}
