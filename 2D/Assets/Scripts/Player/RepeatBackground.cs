using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Transform player;
    private float width;
    private float height;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        width = spriteRenderer.size.x;
        height = spriteRenderer.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x - transform.position.x > width * 2)
        {
            Vector2 vector = new Vector2(width * 4f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
        if(player.position.x - transform.position.x < -width * 2)
        {
            Vector2 vector = new Vector2(width * -4f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
        if (player.position.y - transform.position.y > height * 2)
        {
            Vector2 vector = new Vector2(0, height * 4f);
            transform.position = (Vector2)transform.position + vector;
        }
        if (player.position.y - transform.position.y < -height * 2)
        {
            Vector2 vector = new Vector2(0, height * -4f);
            transform.position = (Vector2)transform.position + vector;
        }


    }
}
