using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameManager.Instance.numMissedVegetables ++;
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);
        GameManager.Instance.score += pointsForVegetable;
    }
}
