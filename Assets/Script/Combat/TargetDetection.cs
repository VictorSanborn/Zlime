using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    public float detectionRadius;

    void Update()
    {
        checkForTarget();
    }

    void checkForTarget()
    {
        var collider = this.gameObject.GetComponent<SphereCollider>();
        RaycastHit[] hitDetect = Physics.BoxCastAll(collider.bounds.center, this.gameObject.transform.localScale, this.gameObject.transform.forward, this.gameObject.transform.rotation, detectionRadius);

        if (hitDetect.Length > 0)
        {
            foreach (RaycastHit hit in hitDetect)
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    // CombatTarget enemy = hit.transform.gameObject.GetComponent<CombatTarget>();
                    // enemy.CalcDamage(damageModifier * damageStat);
                    Debug.Log("ATTACK!!");
                }
            }

        }
    }
}