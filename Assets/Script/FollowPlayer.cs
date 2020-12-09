using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] Transform follow;

    void LateUpdate()
    {
        transform.position = follow.position;
        transform.rotation = follow.rotation;
    }
}
