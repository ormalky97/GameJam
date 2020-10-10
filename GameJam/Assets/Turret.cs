﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int damage;
    public float range;
    public float fireRate;

    public GameObject shot;

    GameObject target;
    Rigidbody2D rb;

    float timeOut = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            FindTarget();
        else
        {
            SetRotation();

            if (timeOut <= 0)
            {
                Shoot();
            }
        } 
    }

    void Shoot()
    {
        //shoot
        //draw
    }

    void SetRotation()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.SetRotation(angle);
    }

    void FindTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Enemies"));
        if (hit != null)
            target = hit.gameObject;
    }
}