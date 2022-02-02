using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    void Awake()
    {
        speed = 2f;
        maxhealth = 5f;
        damage = 3f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
