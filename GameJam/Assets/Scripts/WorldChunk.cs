using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    [Header("Chunk Settings")]
    public int size = 10;
    public int blockChance;     //1 in X Chances will spawn a block

    [Header("Blocks Refs")]
    public GameObject stoneBlock;
    public GameObject ironBlock;
    public GameObject electricBlock;

    [Header("Chances")]
    public int stoneChance;
    public int ironChance;
    public int electricChance;

    //Inner Vars
    int xMin, yMin, xMax, yMax;
    int totalChance;

    // Start is called before the first frame update
    void Awake()
    {
        //Initialize
        totalChance = stoneChance + ironChance + electricChance;

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

    GameObject ChooseNextBlock()
    {
        int rand = Random.Range(1, totalChance);

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
        Collider2D hit = Physics2D.OverlapBox(new Vector2(x, y), new Vector2(1, 1), 0f, LayerMask.GetMask("Blocks"));
        if(hit == null)
            Instantiate(newBlock, new Vector3(x, y, -1), Quaternion.identity);
    }

    void GenerateChunk()
    {
        for (int x = xMin; x <= xMax; x++)
        {
            for (int y = yMin; y <= yMax; y++)
            {
                if(Random.Range(0, blockChance) == 0)
                    GenerateBlock(x, y);
            }
        }

    }
}
