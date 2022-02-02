using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 2f)
        {
            if (Vector3.Distance(transform.position, player.position) < 0.5f)
            {
                Player.money += 1;
                Player.moneyText.text = Player.money.ToString();
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = player.position - transform.position;
                dir.Normalize();
                rb.MovePosition((Vector2)transform.position + (dir * 35 * Time.deltaTime));
            }
        }
        if (Vector2.Distance(transform.position, player.position) > 40)
        {
            Destroy(gameObject);
        }
    }

}
