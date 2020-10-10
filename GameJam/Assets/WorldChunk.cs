using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    public int size = 10;

    public GameObject stoneBlock, ironBlock, electricBlock;
    public int stoneChance, ironChance, electricChance;

    int xMin, yMin, xMax, yMax;

    // Start is called before the first frame update
    void Awake()
    {
        //Get Boundries
        xMin = (int)transform.position.x - size / 2;
        xMax = (int)transform.position.x + size / 2;
        yMin = (int)transform.position.y - size / 2;
        yMax = (int)transform.position.y + size / 2;
    }

    public void NewChunks()
    {
        RaycastHit2D[] hits;

        //above
        hits = Physics2D.RaycastAll(transform.position, Vector2.up, 10f, LayerMask.GetMask("Chunks"));
        if(hits.Length < 2)
        {
            Instantiate(gameObject, new Vector2(transform.position.x, transform.position.y + size), Quaternion.identity);
        }

        //bellow
        hits = Physics2D.RaycastAll(transform.position, Vector2.down, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            Instantiate(gameObject, new Vector2(transform.position.x, transform.position.y - size), Quaternion.identity);
        }

        //left
        hits = Physics2D.RaycastAll(transform.position, Vector2.left, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y), Quaternion.identity);
        }

        //right
        hits = Physics2D.RaycastAll(transform.position, Vector2.right, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y), Quaternion.identity);
        }

        //Top Right
        hits = Physics2D.RaycastAll(transform.position, new Vector2(10, 10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y + size), Quaternion.identity);
        }

        //Top Left
        hits = Physics2D.RaycastAll(transform.position, new Vector2(-10, 10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y + size), Quaternion.identity);
        }

        //Buttom Right
        hits = Physics2D.RaycastAll(transform.position, new Vector2(10, -10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y - size), Quaternion.identity);
        }

        //Buttom Left
        hits = Physics2D.RaycastAll(transform.position, new Vector2(-10, -10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y - size), Quaternion.identity);
        }
    }

    void GenerateBlock(int x, int y)
    {
        GameObject newBlock = null;
        int rand = Random.Range(0, 100);

        if (rand < stoneChance)
        {
            newBlock = Instantiate(stoneBlock, new Vector2(x, y), Quaternion.identity);
        }
        else if (rand < ironChance)
        {
            newBlock = Instantiate(ironBlock, new Vector2(x, y), Quaternion.identity);
        }
        else if (rand < electricChance)
        {
            newBlock = Instantiate(electricBlock, new Vector2(x, y), Quaternion.identity);
        }
    }

    void GenerateChunk()
    {
        for (int x = xMin; x <= xMax; x++)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                GenerateBlock(x, y);
            }
        }

    }
}
