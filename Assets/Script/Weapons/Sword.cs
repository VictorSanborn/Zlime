using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public float damageModifier = 1;
    
    public override void Use(GameObject user){

        float damageStat = user.GetComponent<PlayerCombat>().damageStat;

        var collider = user.GetComponent<CapsuleCollider>();
        RaycastHit[] hitDetect = Physics.BoxCastAll(collider.bounds.center, user.transform.localScale, user.transform.forward, user.transform.rotation, 1.5f);

        if (hitDetect.Length > 0)
        {
            foreach(RaycastHit hit in hitDetect){
                if (hit.transform.gameObject.tag == "enemy"){
                    Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    enemy.CalcDamage(damageModifier * damageStat);
                    Debug.Log(enemy.health);
                }
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
