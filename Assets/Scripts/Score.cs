using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;

    void OnEnable()
    {
        //����� ����� �� �����
        score = TetrisBlock.score;
        scoreText.GetComponent<Text>().text = "" + TetrisBlock.score;
        TetrisBlock.score = 0;
        TetrisBlock.fallTime = 0.8f;
        TetrisBlock.countOfBurnLines = 0;
    }
}
