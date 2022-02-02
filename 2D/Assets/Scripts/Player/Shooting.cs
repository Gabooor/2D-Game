using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float bulletForce = 7f;

    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown == 0)
        {
            if(Player.equippedItem.isWeapon())
            {
                Shoot();
                cooldown = 0.15f;
            }
            else
            {   
                cooldown = 1f;
            }
            //cooldown = 0.01f;
        }
        if (cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
        }
        if (cooldown < 0) cooldown = 0;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Player.equippedItem.GetBullet(), firePoint.position, firePoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
