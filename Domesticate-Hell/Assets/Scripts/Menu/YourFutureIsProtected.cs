// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourFutureIsProtected : MonoBehaviour
{
    [SerializeField]
    private AudioSource yourFutureIsProtectedAudioSource = null;

    [SerializeField]
    private AudioClip yourFutureIsProtectedAudioClip = null;

    [SerializeField]
    private GameObject titlePagePanel = null;

    void Awake()
    {
        titlePagePanel.SetActive(false);
        Invoke("PlayYFIPAudio", 1);
        Invoke("TurnOnMainMenu", 8);
    }

    void PlayYFIPAudio()
    {
        Debug.Log("Playing 'Your Future Is Protected' Audio");
        yourFutureIsProtectedAudioSource.PlayOneShot(yourFutureIsProtectedAudioClip);
    }
}
