using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    Image timerbar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timesUpText;
    private bool start;
    public GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        timesUpText.SetActive(false);
        timerbar = GetComponent<Image>();
        timeLeft  = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        start = cat.GetComponent<PlayerController>().isArrived;
        if (start) {
            if (timeLeft > 0){
                timeLeft -= Time.deltaTime;
                timerbar.fillAmount = timeLeft/maxTime;
            }
            else{
                timesUpText.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
    }
}
