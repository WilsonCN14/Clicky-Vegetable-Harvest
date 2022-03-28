using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION - don't want GameManager to be null so private set
    public static GameManager Instance {get; private set;}
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    [SerializeField] GameObject gameOverScreen;
    private float startDelay = 1.0f;
    private float repeatRate = 1.0f;
    [SerializeField] List<GameObject> vegetablesList;

    // Range of positions for new vegetables
    private float xRange = 16;
    private float zRange = 8;
    private float yPosition = 1;

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

        scoreText.SetText($"Score: {score}");
        livesText.SetText($"Lives: {lives}");
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
        if (lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        CancelInvoke();
        gameOverScreen.SetActive(true);
    }
}
