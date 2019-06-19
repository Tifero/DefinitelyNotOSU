using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject enemy;
    public static int Score;
    public Text scoreText;
    private bool canPlay = true;

    [SerializeField]
    private float spawnDelay = 3;

    private void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        StartCoroutine("SpawnObject");
    }

    private IEnumerator SpawnObject()
    {
        while (canPlay)
        {
            yield return new WaitForSeconds(spawnDelay);

            Instantiate(enemy, new Vector3(Random.Range(-3.5F, 3.5F), Random.Range(-4.5F, 4.5F), 0),
                Quaternion.identity);
        }
    }

    private void Update()
    {
        ScoreCheck();
    }

    private void ScoreCheck()
    {
        scoreText.text = Score.ToString();
        if (Score <= -1)
        {
            scoreText.text = "Lose";
            canPlay = false;
        }
    }
}