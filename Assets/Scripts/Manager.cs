using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject enemy;
    public static bool CanPlay = true;
    public static int Score;
    public static int ComboCount = 1;
    
    [FormerlySerializedAs("Slider")]
    public Slider slider;

    [SerializeField] 
    private float spawnDelay = 2;

    [SerializeField]
    private float difficultyChangeTime;

    private static int _numberInt;
    private SpriteRenderer _sprite;
    private ArrayList enemyList;
    

    public Text comboText;
    public Text scoreText;
    public Sprite[] spriteCount;

    private void Start()
    {
        StartCoroutine("SpawnObject");
        StartCoroutine("GameSpeed");
        _sprite = enemy.GetComponent<SpriteRenderer>();
        _sprite.sprite = spriteCount[0];
        _numberInt = 0;
    }

    private IEnumerator SpawnObject()
    {
        while (CanPlay)
        {
            yield return new WaitForSeconds(spawnDelay);

            var random = Random.Range(-3.5f, 3.5f);
            
            Instantiate(enemy, new Vector3(random, random, 0),
                Quaternion.identity);
            
            if (_numberInt <= 9)
            {
                _sprite.sprite = spriteCount[_numberInt];
                _numberInt++;
            }
            else
            {
                var randomColor = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),1);
                _sprite.color = randomColor;
                _numberInt = 0;
            }
        }
    }

    private void Update()
    {
        ScoreCheck();
        ScoreUpdate();
    }

    private void ScoreCheck()
    {
        slider.value = Score;
        comboText.text = ComboCount.ToString();

        if (Score <= -1)
        {
            CanPlay = false;
        }
    }

    private void ScoreUpdate()
    {
        scoreText.text = Score.ToString();
    }

    private IEnumerator GameSpeed()
    {
        while (CanPlay)
        {
            yield return new WaitForSeconds(difficultyChangeTime);

            spawnDelay -= 0.1f;
        }
    }
}