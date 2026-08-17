using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip forwardSound;
    public AudioClip reverseSound;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlaySound(forwardSound);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlaySound(reverseSound);
        }
        else
        {
            audioSource.Stop();
        }
    }

    void PlaySound(AudioClip sound)
    {
        if (audioSource.clip != sound)
        {
            audioSource.clip = sound;
            audioSource.loop = true;
            audioSource.Play();
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}