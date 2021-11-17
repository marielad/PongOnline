using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip goalSound;
    public AudioClip pongSound;
    private AudioSource audioSource;

    void Awake()
    {
        AudioManager.instance = this;
        audioSource = GetComponent<AudioSource>();
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPongSound(){
        audioSource.PlayOneShot(pongSound);
    }

    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(goalSound);
    }
}
