using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; set;}
    public int score = 0;
    public int numMissedVegetables = 0;
    private float startDelay = 1.0f;
    private float repeatRate = 1.0f;
    public List<GameObject> vegetablesList;

    // Range of positions for new vegetables
    private float xRange = 16;
    private float zRange = 8;
    private float yPosition = 1;
    private int maxMissedVegetables = 3; // If miss this many vegetables, lose game

    private void Start() 
    {
        // Destroy game when go back to main menu
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InvokeRepeating("PlantSeed", startDelay, repeatRate);
    }

    private void PlantSeed()
    {
        // Pick random seed from vegetables
        var index = Random.Range(0, 5);
        var vegetable = vegetablesList[index];

        // Pick random position for new seed
        var position = new Vector3(Random.Range(-xRange, xRange), yPosition, Random.Range(-zRange, zRange));

        // Plant seed at position
        Instantiate(vegetable, position, vegetable.transform.rotation);
    }

    private void Update() 
    {
        if (numMissedVegetables >= maxMissedVegetables)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        CancelInvoke();
    }
}
