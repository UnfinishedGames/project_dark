using System;
using UnityEngine;

public class PlayerSoundManager
{
    private AudioSource stepSound;

    public PlayerSoundManager(AudioSource stepSound)
    {
        this.stepSound = stepSound;
    }

    public void playMovementSound(Vector3 movement)
    {
        // check if we have some movement and play the assigned movement sound
        if (movement.magnitude > 0.1)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
        else
        {
            stepSound.Stop();
        }
    }
}

