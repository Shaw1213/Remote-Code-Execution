using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("---------Audio Sources-----------")]
    [SerializeField] private AudioSource engineSource; // Separate AudioSource for engine sound
    [SerializeField] private AudioSource sfxSource;    // Separate AudioSource for crash sound

    [Header("---------Audio Clips-----------")]
    [SerializeField] private AudioClip engineClip;
    [SerializeField] private AudioClip crashClip;

    public void PlayEngineSound()
    {
        if (engineSource != null && engineClip != null)
        {
            engineSource.clip = engineClip;
            engineSource.loop = true;
            engineSource.Play();
        }
    }

    public void StopEngineSound()
    {
        if (engineSource != null && engineSource.isPlaying)
        {
            engineSource.Stop();
        }
    }

    public void PlayCrashSound()
    {
        if (sfxSource != null && crashClip != null)
        {
            sfxSource.PlayOneShot(crashClip);
        }
    }
}
