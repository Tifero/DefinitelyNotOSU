using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyDelay = 2;
    public GameObject failSprite;

    private void Update()
    {
        StartCoroutine(DestroyCircle());
    }

    private IEnumerator DestroyCircle()
    {
        yield return new WaitForSeconds(destroyDelay);
        var position = transform.position;
        Instantiate(failSprite, new Vector3(position.x, position.y, position.z), Quaternion.identity);

        Manager.Score -= 10;
        Manager.comboCount = 1;

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Manager.CanPlay)
        {
            if (Manager.Score < 100)
            {
                Manager.Score += 10;
            }

            Manager.comboCount += 1;

            Destroy(gameObject);
        }
    }
}