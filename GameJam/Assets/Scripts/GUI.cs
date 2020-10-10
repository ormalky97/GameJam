using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [Header("Text Refs")]
    public Text stone;
    public Text iron;
    public Text electricRock;

    PlayerResources playerResources;

    // Start is called before the first frame update
    void Awake()
    {
        playerResources = GameObject.Find("Player").GetComponent<PlayerResources>();        
    }

    // Update is called once per frame
    void Update()
    {
        stone.text = "Stone: " + playerResources.stone;
        iron.text = "Iron: " + playerResources.iron;
        electricRock.text = "Electric Rock: " + playerResources.electricRock;
    }
}
