using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _score = 0;

    private void Update()
    {
        UpdateScore();
    }
    public void AddScore(int value)
    {
        _score++;
    }

    public void UpdateScore()
    {
        _text.text = _score.ToString();
    }
}
