using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip weaponRifle;
    public AudioClip weaponShotgun;
    public AudioClip weaponToggle;
    public AudioClip enemyDeath;
    public static AudioController Instance { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
