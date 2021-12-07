using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//!!!! remeber to change the audio for player!!!
public class soundsManager : MonoBehaviour
{
	public static AudioClip hitBird;
	public static AudioClip hitPlayer;
	public static AudioSource audioSrc;
	public static float Volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
		hitBird = Resources.Load<AudioClip>("bird_wahhh");
		hitPlayer = Resources.Load<AudioClip>("crashSound");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public static void PlaySound(string clip){
		audioSrc.volume = Volume;
		switch (clip){
			case "bird_wahhh":
			audioSrc.PlayOneShot(hitBird);
			break;
			
			case "crashSound":
			audioSrc.PlayOneShot(hitPlayer);
			break;
			
			default: 
			//well maybe sound error sound?
			break;
		//
		
		
		}
	}
}
