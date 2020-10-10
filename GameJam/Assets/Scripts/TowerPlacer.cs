using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject tower;

    Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
        
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
