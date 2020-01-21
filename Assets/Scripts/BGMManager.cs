using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public GameObject BackgroundMusic;
    public GameObject GameStartPanel;
    public Text gameStartText;
    public Text gameStartTextHighlight;
    private string textContents = "STAGE\n1-1";
    private static float textInputDelay = 0.2f;
    private float timeCount;
    private int charCounter = 0;

    void Awake() {
        timeCount = textInputDelay;
        StartCoroutine(StartBGM());
    }

    void Update() {
        if (charCounter < textContents.Length) {
            if (timeCount <= 0) {
                gameStartText.text += textContents[charCounter];
                gameStartTextHighlight.text += textContents[charCounter];
                timeCount = textInputDelay;
                charCounter += 1;
            }
            else timeCount -= Time.deltaTime;
        }
    }

    IEnumerator StartBGM() {
        yield return new WaitForSeconds(3.7f);
        GameStartPanel.SetActive(false);
        BackgroundMusic.SetActive(true);
    }
}
