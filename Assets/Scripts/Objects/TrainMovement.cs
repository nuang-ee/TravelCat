using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public Vector2 start;
    public Vector2 goal;
    public Vector2 departGoal;
    private float yVelocity = 0.0f;
    public float smoothTime = 1.0f;
    public bool isArrived;
    public bool isDeparting;
    private bool succeed;
    public GameObject GameSucceedPanel;
    void Awake() {
        isArrived = false;
        isDeparting = false;
        succeed = false;
        gameObject.transform.position = new Vector3(start.x, start.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (succeed) {
            GameObject.Find("Player").transform.position = transform.position;
            StartCoroutine(Finish());
        }

        if (!isArrived) {
            float newPosition = Mathf.SmoothDamp(gameObject.transform.position.y, goal.y, ref yVelocity, smoothTime);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newPosition, gameObject.transform.position.z);
            if ((gameObject.transform.position.y - goal.y) <= 0.001f) {
                isArrived = true;
                Debug.Log("Arrived");
            }
        }
        
        if (isDeparting) {
            if (succeed) {
                smoothTime = 5.0f;
            }
            departGoal = goal + new Vector2(0, -300f);
            float newPosition = Mathf.SmoothDamp(gameObject.transform.position.y, departGoal.y, ref yVelocity, smoothTime);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newPosition, gameObject.transform.position.z);
            if ((gameObject.transform.position.y - departGoal.y) <= 1.0f) {
                isDeparting = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            if (coll.gameObject.GetComponent<PlayerController>().isDashing) {
                if (GameObject.Find("ScoreManager") != null) {
                    if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score >= 10) {
                        isDeparting = true;
                        succeed = true;
                    }
                }
                else Debug.Log("ScoreManager Not Found");
            }
        }
    }

    IEnumerator Finish() {
        yield return new WaitForSeconds(2);
        GameSucceedPanel.SetActive(true);
    }
}
