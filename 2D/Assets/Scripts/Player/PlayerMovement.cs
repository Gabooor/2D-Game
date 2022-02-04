using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform characterSprite;
    Vector2 movement;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir;
        lookDir.x = mousePos.x - transform.position.x;
        lookDir.y = mousePos.y - transform.position.y;
        float lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        Quaternion target = Quaternion.Euler(0f, 0f, lookAngle);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (Player.isShooting)
        {
            if (target.eulerAngles.z <= 180)
            {
                characterSprite.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                characterSprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else
        if(movement.x < 0)
        {
            characterSprite.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else 
        if (movement.x > 0)
        {
            characterSprite.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * Player.moveSpeed * Time.fixedDeltaTime);
    }
}
