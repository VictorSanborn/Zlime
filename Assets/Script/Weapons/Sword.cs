using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public float damageModifier = 1;
    private Vector3 lastUsedPosition;

    public override void Use(GameObject user){

        float damageStat = user.GetComponent<PlayerCombat>().damageStat;
        lastUsedPosition = user.transform.position;

        var collider = user.GetComponent<CapsuleCollider>();
        RaycastHit[] hitDetect = Physics.BoxCastAll(collider.bounds.center, user.transform.localScale, user.transform.forward, user.transform.rotation, 1.5f);

        CastVisualization.DrawBoxCast(collider.bounds.center, user.transform.localScale, user.transform.forward, user.transform.rotation, 1.5f);

        if (hitDetect.Length > 0)
        {
            foreach(RaycastHit hit in hitDetect){
                if (hit.transform.gameObject.tag == "enemy"){
                    CombatTarget enemy = hit.transform.gameObject.GetComponent<CombatTarget>();
                    enemy.CalcDamage(damageModifier * damageStat);
                    
                }
            }

        }
    }
}
