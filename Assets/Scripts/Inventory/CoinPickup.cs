using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    public GameObject effect;
    public int coinValue =1;
    private float speed = 10.0f;
    private bool isFlying;
    private Vector3 moveTarget;
    public float coinMovingTime;
    private float deg;

    private void Start()
    {
        coinMovingTime = 1.0f;
        isFlying = true;
        deg = Random.Range(0, 360);
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector3(speed * Mathf.Cos(deg), speed * Mathf.Sin(deg), 0);
    }

    private void Update(){
        if (isFlying) {
            if (gameObject.transform != null) {
                if (coinMovingTime > 0) {            
                    coinMovingTime -= Time.deltaTime;
                }
                else {
                    gameObject.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    isFlying = false;
                    coinMovingTime = 1.0f;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            Instantiate(effect, other.transform.position, Quaternion.identity);
            // Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
            Destroy(gameObject);
            SoundManager.PlaySound("coin");
            ScoreManager.instance.ChangeScore(coinValue);
        }
        
    }
}