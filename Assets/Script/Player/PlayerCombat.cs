using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatTarget
{
    // Start is called before the first frame update
    public Weapon activeSlot;
    public float damageStat;

    void Start()
    {
        activeSlot = new Sword();
        damageStat = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t")){
            Attack();
        }
    }

    void Attack(){
        activeSlot.Use(this.gameObject);
    }

}
