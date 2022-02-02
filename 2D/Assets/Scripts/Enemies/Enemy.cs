using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform healthbar;
    public Transform healthbarbackground;
    public Transform coin;
    protected Transform player;
    protected Rigidbody2D rb;

    protected Vector2 movement;
    protected Vector2 localScale;
    protected Vector2 dir;

    public bool isInRange = false;

    protected float speed = 100f;
    protected float maxhealth = 100;
    protected float health;
    protected float damage = 1;
    protected float distance = 0f;
    protected float attackCooldown = 0f;

    public static Text enemiesKilledText;

    public bool isBoss;
    protected Vector2 size;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = transform.GetComponent<Rigidbody2D>();
        localScale = healthbar.localScale;
        //Debug.Log(isBoss);
        if (isBoss)
        {
            size.x = transform.localScale.x * 1.25f;
            size.y = transform.localScale.y * 1.25f;
            transform.localScale = size;
        }

        if (isBoss)
        {
            maxhealth = maxhealth * 5;
            damage = damage * 5;
        }

        health = maxhealth;

        enemiesKilledText = GameObject.Find("noOfEnemiesKilled").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        dir = player.position - transform.position;
        dir.Normalize();
        movement = dir;
        if(dir.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            healthbarbackground.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0, 0f);
            healthbarbackground.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Vector2.Distance(transform.position, player.position) > 15)
        {
            if (isBoss)
            {
                Vector2 pos = player.position;
                float X = Random.Range(-10f, 10f);
                float Y = 10f;
                bool isPositive;
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    isPositive = true;
                }
                else isPositive = false;
                if (X > 0)
                {
                    if (isPositive)
                    {
                        Y = 10f - X;
                    }
                    else Y = (10f - X) * -1;
                }
                else if (X < 0)
                {
                    if (isPositive)
                    {
                        Y = -10f - X;
                    }
                    else Y = (-10f - X) * -1;
                }
                pos.x += X;
                pos.y += Y;
                transform.position = pos;
            }
            else
            {
                WaveSpawner.enemiesRemaining--;
                WaveSpawner.enemiesRemainingText.text = "Enemies remaining: " + WaveSpawner.enemiesRemaining.ToString();
                Destroy(gameObject);
            }
        }


        if (isInRange)
        {
            if(attackCooldown == 0)
            {
                DamagePlayer();
                attackCooldown = 1f;
            }
            if(attackCooldown > 0)
            {
                attackCooldown -= 1f * Time.fixedDeltaTime;
            }
            if (attackCooldown < 0) attackCooldown = 0;
        }
        else
        {
            moveCharacter(movement);
        }
    }

    public virtual void takeDamage(float dam)
    {
        health -= dam;
        //Debug.Log("Took " + dam + " damage");
        if (health > 0)
        {
            localScale.x = health / maxhealth;
            healthbar.localScale = localScale;
            healthbar.localPosition = new Vector3(0 - ((1 - (health / maxhealth)) / 2), 0f, 0f);
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        if (isBoss)
        {
            //5 coin
            for (int i = 0; i < 5; i++)
            {
                SpawnCoin();
            }
            Player.increaseXP(5);
        }
        else
        {
            //1-2 coin
            int rand = (int)Random.Range(0f, 2f) + 1;
            for (int i = 0; i < rand; i++)
            {
                SpawnCoin();
            }
            Player.increaseXP(1);
        }
        if (Random.Range(0f, 1f) > 0.98f)
        {
            ItemWorld.SpawnItemWorld(transform.position, new Item { itemType = Item.ItemType.HealthPotion});
        }
        Player.enemies.Remove(gameObject);
        Destroy(gameObject);
        Player.enemiesKilled += 1;
        enemiesKilledText.text = Player.enemiesKilled.ToString();
        WaveSpawner.enemiesRemaining--;
        WaveSpawner.enemiesRemainingText.text = "Enemies remaining: " + WaveSpawner.enemiesRemaining.ToString();
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void DamagePlayer()
    {
        Player.health -= damage;
        Player.healthText.text = Player.health.ToString();
    }

    void SpawnCoin()
    {
        Vector3 tempPos = transform.position;
        float randX = Random.Range(0f, 0.5f);
        if (Random.Range(0f, 1f) > 0.5)
        {
            randX = randX * -1;
        }
        float randY = Random.Range(0f, 0.5f);
        if (Random.Range(0f, 1f) > 0.5)
        {
            randY = randY * -1;
        }
        tempPos.x = tempPos.x + randX;
        tempPos.y = tempPos.y + randY;
        Instantiate(coin, tempPos, transform.rotation);
    }
}
