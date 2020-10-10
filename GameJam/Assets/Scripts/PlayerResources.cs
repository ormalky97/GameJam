using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int stone;
    public int iron;
    public int electricRock;

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

            case "Electric Rock":
                electricRock += amount;
                break;
        }

        Debug.Log(amount + " " + type + " Added");
    }
}
