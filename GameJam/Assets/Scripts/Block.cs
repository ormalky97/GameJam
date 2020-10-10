using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string type;
    public int amount;

    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        player.GetComponent<PlayerResources>().AddResource(type, amount);
    }
}
