using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
