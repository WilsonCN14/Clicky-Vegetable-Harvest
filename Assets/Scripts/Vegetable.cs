using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE - Carrot, Garlic, Pea, Pumpkin, and Tomato inherit from Vegetable
// POLYMORPHISM - Each type of vegetable has a different timeToDie and pointsForVegetable
// ABSTRACTION - Each vegetable doesn't need to know details of how each function works, they just need timeToDie and pointsForVegetable
public class Vegetable : MonoBehaviour
{
    private GameManager gameManager;
    public float timeToDie = 2.0f;
    public int pointsForVegetable = 10;

    void Start()
    {
        StartCoroutine(WaitToDie());
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
        GameManager.Instance.lives --;
        GameManager.Instance.livesText.SetText($"Lives: {GameManager.Instance.lives}");
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);
        GameManager.Instance.score += pointsForVegetable;
        GameManager.Instance.scoreText.SetText($"Score: {GameManager.Instance.score}");
    }
}
