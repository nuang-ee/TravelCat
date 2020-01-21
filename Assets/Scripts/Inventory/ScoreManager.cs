using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance ==null)
        {
            instance = this;
            text.text = score.ToString() + "/10";
        }
        
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text =  score.ToString() + "/10";
    }
}
