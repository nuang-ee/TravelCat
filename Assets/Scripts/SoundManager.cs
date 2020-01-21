using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip dashsound, coinPickUpSound, meowSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        dashsound = Resources.Load<AudioClip> ("dash");
        coinPickUpSound = Resources.Load<AudioClip> ("coin");
        meowSound = Resources.Load<AudioClip> ("meow");
        audioSrc = GetComponent<AudioSource>();
        if (dashsound == null) Debug.Log("dashSound NULL");
        if (coinPickUpSound == null) Debug.Log("coinpickupsound NULL");
        if (audioSrc == null) Debug.Log("audiosrc NULL");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip){
            case "dash":
                audioSrc.PlayOneShot(dashsound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinPickUpSound);
                break;
            case "meow":
                audioSrc.PlayOneShot(meowSound);
                break;
        }
    }
}
