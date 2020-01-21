using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    Image timerbar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject TimeOutPanel;
    private bool start;
    public GameObject cat;
    public TrainMovement train;
    public bool gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        train = GameObject.Find("Train").GetComponent<TrainMovement>();
        start = false;
        TimeOutPanel.SetActive(false);
        timerbar = GetComponent<Image>();
        timeLeft  = maxTime;
        Time.timeScale = 1;
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
                if (!gameOver) {
                    gameOver = true;
                    train.isDeparting = true;
                    cat.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (gameOver && !train.isDeparting) {
                    TimeOutPanel.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
        
    }
}
