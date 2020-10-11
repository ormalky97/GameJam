using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    [Header("Chunk Settings")]
    public int size = 10;
    //public int blockChance;     //1 in X Chances will spawn a block

    [Header("Blocks Refs")]
    public GameObject stoneBlock;
    public GameObject ironBlock;
    public GameObject electricBlock;

    [Header("Chances")]
    public float stoneChance;
    public float ironChance;
    public float electricChance;

    //Inner Vars
    int xMin, yMin, xMax, yMax;
    float totalChance;
    float blockChance;
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        //Initialize
        totalChance = stoneChance + ironChance + electricChance;
        blockChance = 10000 / (Vector2.Distance(transform.position, new Vector2(0, 0)) / 2);
        player = GameObject.Find("Player");

        //Get Boundries
        xMin = (int)transform.position.x - size / 2;
        xMax = (int)transform.position.x + size / 2;
        yMin = (int)transform.position.y - size / 2;
        yMax = (int)transform.position.y + size / 2;

        //Populate Chunk
        GenerateChunk();
    }

    public void NewChunks()
    {
        RaycastHit2D[] hits;
        GameObject temp;

        //above
        hits = Physics2D.RaycastAll(transform.position, Vector2.up, 10f, LayerMask.GetMask("Chunks"));
        if(hits.Length < 2)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x, transform.position.y + size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //bellow
        hits = Physics2D.RaycastAll(transform.position, Vector2.down, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x, transform.position.y - size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //left
        hits = Physics2D.RaycastAll(transform.position, Vector2.left, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //right
        hits = Physics2D.RaycastAll(transform.position, Vector2.right, 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 2)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //Top Right
        hits = Physics2D.RaycastAll(transform.position, new Vector2(10, 10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y + size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //Top Left
        hits = Physics2D.RaycastAll(transform.position, new Vector2(-10, 10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y + size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //Buttom Right
        hits = Physics2D.RaycastAll(transform.position, new Vector2(10, -10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x + size, transform.position.y - size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }

        //Buttom Left
        hits = Physics2D.RaycastAll(transform.position, new Vector2(-10, -10), 10f, LayerMask.GetMask("Chunks"));
        if (hits.Length < 4)
        {
            temp = Instantiate(gameObject, new Vector2(transform.position.x - size, transform.position.y - size), Quaternion.identity);
            //temp.GetComponent<WorldChunk>().blockChance = Random.Range(minChance, maxChance);
        }
    }

    GameObject ChooseNextBlock()
    {
        float rand = Random.Range(0, totalChance+1);

        if (rand <= electricChance)
            return electricBlock;
        else if (rand <= ironChance + electricChance)
            return ironBlock;
        else if (rand <= stoneChance + ironChance + electricChance)
            return stoneBlock;

        return null;
    }

    void GenerateBlock(int x, int y)
    {
        GameObject newBlock = ChooseNextBlock();
        GameObject temp;

        Collider2D hit = Physics2D.OverlapPoint(new Vector2(x, y), LayerMask.GetMask("Blocks"));
        if(hit == null)
        {
            temp = Instantiate(newBlock, new Vector3(x, y, -1), Quaternion.identity);
            temp.transform.parent = gameObject.transform;
        }
    }

    void GenerateChunk()
    {
        if(blockChance != 0)
        {
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    if (Random.Range(0, (int)blockChance) == 0)
                        GenerateBlock(x, y);
                }
            }
        }
    }
}
