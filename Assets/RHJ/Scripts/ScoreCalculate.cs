using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculate : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // StateManager�� �ν��Ͻ��� ���� ������ ���
        int score = CalculateScore();
        DisplayScore(score);
        DBRepository.Instance.saveDB(score);
    }

    int CalculateScore()
    {
        int hp = StateManager.Instance.ReturnHP();
        int oxygen = StateManager.Instance.ReturnOxygen();
        int gas = StateManager.Instance.ReturnGas();

        // ���� ���
        int score = hp * 1234 + oxygen * 1111  - gas * 1177;
        return score;
    }

    void DisplayScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
