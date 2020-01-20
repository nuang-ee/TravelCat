using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public float genTimeMax;
    public float genTimeMin;
     public GameObject NPCObject;
    private float genTime;

    void Update()
    {
        if (genTime <= 0) {
            GameObject generated = Instantiate(NPCObject, transform.position, Quaternion.identity);
            generated.transform.GetComponent<NPCPatrol>().speed = Random.Range(1f, 1.5f);
            genTime = Random.Range(genTimeMin, genTimeMax);
        }
        else {
            genTime -= Time.deltaTime;
        }
    }
}
