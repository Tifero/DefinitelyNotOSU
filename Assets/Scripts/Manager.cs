using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject enemy;
    public static bool CanPlay = true;
    public static int Score;
    public Slider Slider;

    [SerializeField] private float spawnDelay = 2;
    public static int comboCount = 1;
    public Text comboText;
    public Text scoreText;

    private void Start()
    {
        StartCoroutine("SpawnObject");
    }

    private IEnumerator SpawnObject()
    {
        while (CanPlay)
        {
            yield return new WaitForSeconds(spawnDelay);

            Instantiate(enemy, new Vector3(Random.Range(-3.5F, 3.5F), Random.Range(-4.5F, 4.5F), 0),
                Quaternion.identity);
        }
    }

    private void Update()
    {
        ScoreCheck();
        TimeEffect();
        ScoreUpdate();
    }

    private void ScoreCheck()
    {
        Slider.value = Score;
        comboText.text = comboCount.ToString();
        
        if (Score <= -1)
        {
            CanPlay = false;
        }
    }

    private void ScoreUpdate()
    {
        scoreText.text = Score.ToString();
    }

    private void TimeEffect()
    {
        if (Score == 100)
        {
            spawnDelay = 0.5f;
        }
    }
}