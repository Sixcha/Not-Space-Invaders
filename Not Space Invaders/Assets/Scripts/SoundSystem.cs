using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private static bool damageSignal = false;
    private static bool destroySignal = false;
    private static bool playerShootSignal = false;

    AudioSource damagedAudio;
    AudioSource destroyedAudio;
    AudioSource playerShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] aSources = GetComponents<AudioSource>();
        damagedAudio = aSources[0];
        destroyedAudio = aSources[1];
        playerShoot = aSources[2];
    }

    // Update is called once per frame
    void Update()
    {
        DamagedSound();
        DestroySound();
        PlayerShootSound();
    }

    void PlayerShootSound()
    {
        if (playerShootSignal)
        {
            playerShoot.Play();
            playerShootSignal = false;
        }
    }

    void DamagedSound()
    {
        if (damageSignal)
        {
            damagedAudio.Play();
            damageSignal = false;
        }
    }

    void DestroySound()
    {
        if (destroySignal)
        {
            destroyedAudio.Play();
            destroySignal = false;
        }
    }

    public static void SetDamageSignal()
    {
        damageSignal = true;
    }

    public static void SetDestroySignal()
    {
        destroySignal = true;
    }

    public static void SetPlayerShootSignal()
    {
        playerShootSignal = true;
    }
}
