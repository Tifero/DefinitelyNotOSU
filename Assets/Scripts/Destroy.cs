using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int destroyDelay = 2;

    private void OnMouseDown()
    {
        var localScale = gameObject.transform.localScale.x;
        
        if (localScale <= 0.75f)
        {
            Manager.Score += 5;
        }

        if (localScale >= 0.75f && localScale <= 1f)
        {
            Manager.Score += 100;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        StartCoroutine(DestroyObj());
    }

    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
        Manager.Score-= 15;
    }
}