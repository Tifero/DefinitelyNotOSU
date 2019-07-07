using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyDelay = 2;
    public GameObject failSprite;

    private void Start()
    {
        StartCoroutine(DestroyCircle());
    }

    private IEnumerator DestroyCircle()
    {
        yield return new WaitForSeconds(destroyDelay);
        var position = transform.position;
        Instantiate(failSprite, new Vector3(position.x, position.y, position.z), Quaternion.identity);

        Manager.comboCount = 1;

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Manager.CanPlay)
        {
            Manager.Score += 10 * Manager.comboCount;
            Manager.comboCount += 1;
            Destroy(gameObject);
        }
    }
}