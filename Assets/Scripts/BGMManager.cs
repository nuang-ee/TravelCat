using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public GameObject BackgroundMusic;
    public GameObject GameStartPanel;
    public GameObject TrainSound;
    public Text gameStartText;
    public Text gameStartTextHighlight;
    private string textContents = "STAGE\n1-1";
    private static float textInputDelay = 0.2f;
    private float timeCount;
    private int charCounter = 0;
    public float fadeTime = 3.0f;
    public AudioSource source;
    private float t;

    void Awake() {
        t = fadeTime;
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

        t -= Time.deltaTime;
        source.volume = t/fadeTime;
    }

    IEnumerator StartBGM() {
        yield return new WaitForSeconds(3.7f);
        TrainSound.SetActive(false);
        GameStartPanel.SetActive(false);
        BackgroundMusic.SetActive(true);
    }

    IEnumerator _FadeSound() {
     float t = fadeTime;
     while (t > 0) {
         yield return null;
         t-= Time.deltaTime;
         source.volume = t/fadeTime;
     }
     yield break;
 }
}
