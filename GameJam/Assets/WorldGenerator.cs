using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public int chunkSize;
    public int renderDistance;

    public GameObject stoneBlock, ironBlock, electricBlock;
    public int stoneChance, ironChance, electricChance;
    int totalChance;

    GameObject player;

    int xMax, xMin, yMax, yMin;

    private void Awake()
    {
        totalChance = stoneChance + ironChance + electricChance;
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

    void GenerateChunk(int xMin, int yMin, int xMax, int yMax)
    {
        for(int x = xMin; x <= xMax; x++)
        {
            for(int y = yMin; y <= yMax; y++)
            {
                GenerateBlock(x, y);
            }
        }

    }
}
