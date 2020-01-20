using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcStatus : MonoBehaviour
{
    public bool isNormal;
    public bool isAngry;
    private float angryTime;
    private GameObject AngryState;
    private GameObject QuestionState;

    void Awake() {
        isNormal = true;
        isAngry = false;
        AngryState = transform.GetChild(0).gameObject;
        QuestionState = transform.GetChild(1).gameObject;
    }


    void Update() {
        if (angryTime > 0) angryTime -= Time.deltaTime;

        if (isAngry) {
            gameObject.GetComponent<NPCAngry>().enabled = true;
            gameObject.GetComponent<NPCPatrol>().enabled = false;
            AngryState.SetActive(true);
            if (angryTime <= 0) {
                calmDown();
            }
        }
        else if (isNormal) {
            calmDown();
        }
    }


    private void calmDown() {
        gameObject.GetComponent<NPCAngry>().enabled = false;
        gameObject.GetComponent<NPCPatrol>().enabled = true;
        isAngry = false;
        isNormal = true;
        AngryState.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            if (collider.gameObject.GetComponent<PlayerController>() != null) {
                if (collider.gameObject.GetComponent<PlayerController>().isDashing) {
                    QuestionState.SetActive(true);
                    isNormal = false;
                    StartCoroutine(getAngry(collider));
                }

                if (isAngry) {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    IEnumerator getAngry(Collider2D collider) {
        gameObject.GetComponent<NPCPatrol>().enabled = false;
        yield return new WaitForSecondsRealtime(2);
        QuestionState.SetActive(false);
        isAngry = true;
        gameObject.GetComponent<NPCAngry>().player = collider.gameObject;
        angryTime = 3.0f;
    }
}
