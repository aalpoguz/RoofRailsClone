using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectDiamonds : MonoBehaviour
{
    private int score = 0;
    [Header("Skor")]
    public TextMeshProUGUI scoreText;
    private float diamonds = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("diamond"))
        {
            Debug.Log("diamond degdi");
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
        }
    }
}
