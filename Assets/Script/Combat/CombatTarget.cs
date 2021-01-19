using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    void Start()
    {
        GetComponentInChildren<TextMesh>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            Destroy(this.gameObject);
        }
    }

    public void CalcDamage(float damage){
        health -= damage;
        GetComponentInChildren<TextMesh>().text = health.ToString();
    }
}
