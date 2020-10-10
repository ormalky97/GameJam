using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;
    Camera cam;
    PlayerResources resources;

    public GameObject placer1;

    Vector2 movement;
    float angle;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        LookAtMouse();  //using SetRotation in FixedUpdate

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            GameObject temp = Instantiate(placer1, transform.position, Quaternion.identity);
            Debug.Log(temp.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "World")
        {
            collision.GetComponent<WorldChunk>().NewChunks();
        }
    }

    private void FixedUpdate()
    {
        //Movement & Rotation
        rb.velocity = movement.normalized * moveSpeed;
        rb.SetRotation(angle);
    }

    //Update angle to look at mouse
    void LookAtMouse()
    {
        Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //rotation only updates in FixedUpdate
    }
}
