using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public List<AudioClip> music;
    public List<AudioClip> radio;
    public AudioClip publicCrowd;
    public AudioSource speakers;
    public int musicClips;
    public int radioClips;
    public bool isRadio;

    void Update()
    {
        if (speakers.isPlaying == false && !isRadio) 
        {
            speakers.clip = radio[Random.Range(0, radio.Count - 1)];
            speakers.enabled = false;
            speakers.enabled = true;
            isRadio = true;
        }
        else if (speakers.isPlaying == false && isRadio) 
        {
            speakers.clip = music[Random.Range(0, music.Count - 1)];
            speakers.enabled = false;
            speakers.enabled = true;
            isRadio = false;
        }
    }

    public void NextSong() 
    {
        if (isRadio)
        {   
            speakers.clip = music[Random.Range(0, music.Count - 1)];
            speakers.enabled = false;
            speakers.enabled = true;
            isRadio = false;
        }

    }
}