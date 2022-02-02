using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    void Awake()
    {
        speed = 0.6f;
        maxhealth = 15f;
        damage = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
