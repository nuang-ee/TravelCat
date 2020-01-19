using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public PlayerController player;

    private float t = 0;
    private float targetTime = 1.5f;
    private bool finished;
    private bool init;
    public GameObject train;

    void Awake() {
        finished = false;
        init = true;
    }

    void Update()
    {
        if (t <= targetTime && init && !player.isArrived) { //Zoom in
            t += Time.deltaTime;
            transform.GetComponent<Camera>().orthographicSize = Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, 4.0f, t/targetTime);
            if (t > targetTime) init = false;
        }

        if (!player.isArrived) {
            t = 0;
            transform.position = player.gameObject.transform.position - new Vector3(0f, 0f, 100f);
        }

        else {
            if (t <= targetTime) { //Zoom out
                t += Time.deltaTime;
                transform.GetComponent<Camera>().orthographicSize = Mathf.Lerp(transform.GetComponent<Camera>().orthographicSize, 6.0f, t/targetTime);
            }
            transform.position = player.gameObject.transform.position - new Vector3(0f, 0f, 100f);
            if (!finished) {
                transform.rotation = Quaternion.identity;
                transform.GetComponent<Camera>().orthographicSize = 6.0f;
                finished = true;
            }
        }
    }
}
