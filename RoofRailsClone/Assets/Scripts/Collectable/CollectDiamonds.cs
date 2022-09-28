using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CollectDiamonds : MonoBehaviour
{
    public int score = 0;
    [SerializeField] GameObject animatedDiamondPrefab;
    [SerializeField] Transform target;
    [SerializeField] int maxDiamonds;
    Queue<GameObject> diamondsQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation Settings")]
    [SerializeField][Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField][Range(0.9f, 2f)] float maxAnimDuration;
    [SerializeField] Ease easeType;
    [SerializeField] float spread;

    Vector3 targetPosition;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private float diamonds = 0;

    private void Awake()
    {
        targetPosition = target.localPosition;

        PrepareDiamonds();
    }

    void PrepareDiamonds()
    {
        GameObject diamond;
        for (int i = 0; i < maxDiamonds; i++)
        {
            diamond = Instantiate(animatedDiamondPrefab);
            diamond.transform.parent = transform;
            diamond.SetActive(false);
            diamondsQueue.Enqueue(diamond);
        }


    }

    void Animate(Vector3 collectedDiamondPos, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (diamondsQueue.Count > 0)
            {
                GameObject diamond = diamondsQueue.Dequeue();
                diamond.SetActive(true);

                diamond.transform.position = collectedDiamondPos + new Vector3( Random.Range(-spread,spread),0f,0f);

                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                diamond.transform.DOMove(targetPosition, duration)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    diamond.SetActive(false);
                    diamondsQueue.Enqueue(diamond);

                    diamonds++;
                });
            }
        }
    }

    public void AddDiamonds(Vector3 collectedDiamondPos, int amount)
    {
        Animate(collectedDiamondPos, amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("diamond"))
        {
            Debug.Log("diamond degdi");
            AddDiamonds(other.transform.position, 1);
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
        }
    }
}
