using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static SoundManager sndMan;

    private AudioSource audioSrc;

    private AudioClip[] dashSounds;

    private int randomDashSound;

    private AudioClip[] sprungSounds;

    private int randomSprungSound;
    
    private AudioClip[] deathSounds;

    private int randomDeathSound;

    private AudioClip[] respawnSounds;

    private int randomRespawnSound;

    private AudioClip[] collectedSounds;

    private int randomCollectedSound;

    void Start()
    {
        sndMan = this;
        audioSrc = GetComponent<AudioSource>();
        dashSounds = Resources.LoadAll<AudioClip>("DashSounds");
        sprungSounds = Resources.LoadAll<AudioClip>("SprungSounds");
        deathSounds = Resources.LoadAll<AudioClip>("DeathSounds");
        respawnSounds = Resources.LoadAll<AudioClip>("SpawnSounds");
        collectedSounds = Resources.LoadAll<AudioClip>("CollectingSounds");
    }

    public void PlayDashSound()
    {
        randomDashSound = Random.Range(0, 8);
        audioSrc.PlayOneShot(dashSounds[randomDashSound]);
    }
    public void PlaySprungSound()
    {
        randomSprungSound = Random.Range(0, 11);
        audioSrc.PlayOneShot(sprungSounds[randomSprungSound]);
    }
    public void PlayDeathSound()
    {
        randomDeathSound = Random.Range(0, 7);
        audioSrc.PlayOneShot(deathSounds[randomDeathSound]);
    }
    public void PlayRespawnSound()
    {
        randomRespawnSound = Random.Range(0,0);
        audioSrc.PlayOneShot(respawnSounds[randomRespawnSound]);
    }
    public void PlayCollectedSound()
    {
        randomCollectedSound = Random.Range(0, 7);
        audioSrc.PlayOneShot(collectedSounds[randomCollectedSound]);
    }
}
