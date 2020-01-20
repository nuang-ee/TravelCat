using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float movingTime;
    private int moveTarget;
    private bool pathFinding;
    
    private int checkStopTime;
    private float stopWatch;
    private Vector3 lastPosition;

    public List<Transform> moveSpot;
    public float minX, maxX, minY, maxY;
    private Vector3 randomMoveSpot;
    private Vector3 tempMoveSpotSave;

    void Awake() {
        waitTime = startWaitTime;
        //moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
        GameObject MoveSpots = GameObject.Find("moveSpots");
        int SpotCount = MoveSpots.transform.childCount;
        for (int i = 0; i < SpotCount; i++) {
            moveSpot.Add(MoveSpots.transform.GetChild(i));
        }
        moveTarget = 0;
        randomMoveSpot = moveSpot[moveTarget].position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        pathFinding = false;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, randomMoveSpot, speed * Time.deltaTime);
        Vector2 moving = new Vector2(randomMoveSpot.x - transform.position.x, randomMoveSpot.y - transform.position.y);
        moving.Normalize();
        gameObject.GetComponent<Animator>().SetFloat("Horizontal", moving.x);
        gameObject.GetComponent<Animator>().SetFloat("Vertical", moving.y);
        gameObject.GetComponent<Animator>().SetFloat("Speed", moving.magnitude);

        movingTime -= Time.deltaTime;

        if (Vector2.Distance(transform.position, randomMoveSpot) < 0.2f) {
            if (!pathFinding) {
                randomMoveSpot = moveSpot[moveTarget].position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                moveTarget += 1;
                if (moveTarget >= moveSpot.Count) {
                    //gameObject.transform.position = moveSpot[0].transform.position;
                    //moveTarget = 0;
                    Destroy(gameObject);
                }
            }
            else randomMoveSpot = tempMoveSpotSave;
        }


        if (Vector3.Distance(transform.position, lastPosition) < 0.1f) {
            if (stopWatch <= 0) {
                {
                    float horizontalDistance = Mathf.Abs(transform.position.x - lastPosition.x);
                    float verticalDistance = Mathf.Abs(transform.position.y - lastPosition.y);
                    tempMoveSpotSave = randomMoveSpot;
                    stopWatch = checkStopTime;
                    if (horizontalDistance >= verticalDistance) {
                        randomMoveSpot = transform.position + new Vector3(1.0f, 0, 0);
                    }
                    else randomMoveSpot = transform.position + new Vector3(0, 1.0f, 0);
                }
            }
            else stopWatch -= Time.deltaTime;
        }
        
    }
}
