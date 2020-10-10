using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int stone;
    public int iron;

    public void AddResource(string type, int amount)
    {
        switch (type)
        {
            case "Stone":
                stone += amount;
                break;

            case "Iron":
                iron += amount;
                break;
        }

        Debug.Log(amount + " " + type + " Added");
    }
}
