using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float timer = 0;
    //protected float aliveTime = 1.5f;
    public static float damage = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1f * Time.deltaTime;
        if(timer > Player.equippedItem.GetAliveTime())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag.Equals("Enemy"))
        {
            Enemy enemy = col.transform.GetComponent<Enemy>();
            switch (Player.equippedItem.GetName())
            {
                default:
                case "Sword": enemy.takeDamage(Player.equippedItem.GetDamage(Player.swordLevel)); break;
                case "Staff": enemy.takeDamage(Player.equippedItem.GetDamage(Player.staffLevel)); break;
            }
            Destroy(gameObject);
        }
    }
}
