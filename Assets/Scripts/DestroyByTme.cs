using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTme : MonoBehaviour
{
    private const float DestroyDelay = 1f;

    private void Update()
    {
        StartCoroutine(DestroyCircle());
    }
    
    private IEnumerator DestroyCircle()
    {
        yield return new WaitForSeconds(DestroyDelay);
        Destroy(gameObject);
    }
}
