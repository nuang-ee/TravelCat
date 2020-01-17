using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public Vector2 goal = new Vector3(-12f, -4f, 0);
    private float yVelocity = 0.0f;
    public float smoothTime = 1.0f;
    public bool isArrived = false;
    void Awake() {
        gameObject.transform.position = new Vector3(-12f, 9f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArrived) {
            float newPosition = Mathf.SmoothDamp(gameObject.transform.position.y, goal.y, ref yVelocity, smoothTime);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newPosition, gameObject.transform.position.z);
            if ((gameObject.transform.position.y - goal.y) <= 0.001f) {
                isArrived = true;
                Debug.Log("Arrived");
            }
        }
    }
}
