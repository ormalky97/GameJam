using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public int cost;
    public float fireRate;
    public float range;

    Rigidbody2D rb;
    GameObject target;
    float timeOut;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FindTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Enemies"));
        if (hit != null)
            target = hit.gameObject;
    }

    void LookAtEnemy()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.SetRotation(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindTarget();
        }
        else
        {
            //shoot at target

            LookAtEnemy();
        }
    }
}
