using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _loose;
    
    private void Start()
    {
        _loose = GetComponent<Text>();
        _loose.text = "1111111";
    }

    private void Update()
    {
        _loose.text = ScoreCount.Score.ToString();
        if (ScoreCount.Score <= -1)
        {
            _loose.text = "You Lose";
        }
    }
}
