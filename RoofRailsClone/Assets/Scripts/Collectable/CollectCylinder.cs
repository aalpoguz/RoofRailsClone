using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCylinder : MonoBehaviour
{
    int cylScore = 0;
    public TextMeshProUGUI cylText;
    public GameObject cylNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            cylScore++;
            cylText.text = cylScore.ToString();
            Debug.Log("degdi");
            transform.localScale = new Vector3(transform.localScale.x, +transform.localScale.y + 0.5f, transform.localScale.z);
            Destroy(other.gameObject);
            cylNum.SetActive(true);
            cylNum.transform.localPosition = new Vector3(transform.position.x + 8f, +transform.position.y + 2f, transform.position.z);
            StartCoroutine(destroyCyl());
        }
    }

    IEnumerator destroyCyl()
    {
        yield return new WaitForSeconds(1f);
        cylNum.SetActive(false);
    }
}
