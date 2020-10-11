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
        GenerateAmount();
    }

    void GenerateAmount()
    {
        int dis = (int) Vector2.Distance(transform.position, new Vector2(0, 0));

        switch (type)
        {
            case "Stone":
                if (dis / 100 > 0)
                    amount = Random.Range(1, 5) * dis / 100;
                else
                    amount = Random.Range(1, 5);
                break;

            case "Iron":
                if (dis / 200 > 0)
                    amount = Random.Range(1, 4) * dis / 200;
                else
                    amount = Random.Range(1, 2);
                break;

            case "Electric Rock":
                if (dis / 200 > 0)
                    amount = Random.Range(1, 3) * dis / 200;
                else
                    amount = Random.Range(1, 2);
                break;
        }
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
