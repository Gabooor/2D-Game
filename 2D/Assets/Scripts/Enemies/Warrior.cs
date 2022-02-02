using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    void Awake()
    {
        speed = 1.5f;
        maxhealth = 10;
        damage = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
