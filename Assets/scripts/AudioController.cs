using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip jumpSound;
    public AudioClip winSound;
    public AudioClip dieSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayJump()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = jumpSound;
        source.Play();
    }

    public void PlayWin()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = winSound;
        source.Play();
    }

    public void PlayDie()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = dieSound;
        source.Play();
    }
}
