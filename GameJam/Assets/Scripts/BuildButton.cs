using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    //Placer
    public GameObject placer;

    //Costs
    public int stoneCost;
    public int ironCost;

    PlayerResources playerRes;

    // Start is called before the first frame update
    void Awake()
    {
        playerRes = GameObject.Find("Player").GetComponent<PlayerResources>();
    }

    public bool CheckResources()
    {
        if (stoneCost > playerRes.stone ||
            ironCost > playerRes.iron)
            return false;

        return true;
    }

    public void Build()
    {
        if(CheckResources())
        {
            Instantiate(placer, transform.position, Quaternion.identity);
        }
    }
}
