using System.Collections;
using TMPro;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int destoyDelay;
    private TextMeshProUGUI _loose;

    private void Start()
    {
        _loose = GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        ScoreCount.Score++;
    }

    private void Update()
    {
        StartCoroutine(DestroyObj());
    }

    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(destoyDelay);
        Destroy(gameObject);
        ScoreCount.Score--;
    }
}