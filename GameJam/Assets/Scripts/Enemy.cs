using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float moveSpeed;

    GameObject player;
    GameObject target;
    Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        target = GameObject.Find("Base");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GoToTarget();
    }

    public void RecieveDamage(int amount, GameObject source)
    {
        health -= amount;
        target = source;

        if (health <= 0)
            Die();
    }

    void GoToTarget()
    {
        movement = target.transform.position - transform.position;
        rb.velocity = movement.normalized * moveSpeed;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
