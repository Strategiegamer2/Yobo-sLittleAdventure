using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] public int score = 0;
    public TextMeshProUGUI score_text;

    public void RaiseScore(int raiseNumber) //raises it by one, so do this one time
    {
        score = score + 100; // score up by 100
        score_text.text = "Score: " + score.ToString(); // show it in game
    }
}
