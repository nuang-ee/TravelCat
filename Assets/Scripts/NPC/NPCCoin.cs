using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCCoin : MonoBehaviour
{
    public GameObject coin;

    private float time;
    
    private GameObject newCoinInstance;
    private int catTouched = 0; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            if (catTouched <2){
            newCoinInstance = Instantiate(coin, transform.position, Quaternion.identity);
            catTouched += 1;
            }
        }
        
    }
}
