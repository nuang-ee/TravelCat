using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAngry : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Awake() {
        speed = 3.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector2 moving = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            moving.Normalize();
            gameObject.GetComponent<Animator>().SetFloat("Horizontal", moving.x);
            gameObject.GetComponent<Animator>().SetFloat("Vertical", moving.y);
            gameObject.GetComponent<Animator>().SetFloat("Speed", moving.magnitude);
        }
    }
}
