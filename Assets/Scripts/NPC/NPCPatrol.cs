using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float movingTime;

    public Vector2 moveSpot;
    public float minX, maxX, minY, maxY;

    void Awake() {
        waitTime = startWaitTime;
        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        Vector2 moving = new Vector2(moveSpot.x - transform.position.x, moveSpot.y - transform.position.y);
        moving.Normalize();
        gameObject.GetComponent<Animator>().SetFloat("Horizontal", moving.x);
        gameObject.GetComponent<Animator>().SetFloat("Vertical", moving.y);
        gameObject.GetComponent<Animator>().SetFloat("Speed", moving.magnitude);

        movingTime -= Time.deltaTime;

        if (Vector2.Distance(transform.position, moveSpot) < 0.2f) {
            if (waitTime <= 0) {
                waitTime = startWaitTime;
                moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
            } else {
                waitTime -= Time.deltaTime;
            }
        }

        else if (movingTime <= 0) {
            moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            movingTime = Random.Range(0, 10);
        }
    }
}
