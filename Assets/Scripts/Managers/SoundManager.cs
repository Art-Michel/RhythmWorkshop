using UnityEngine;

public class SoundManager : LocalManager<SoundManager>
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip plouf;

    private void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void ShootSound()
    {
        PlaySound(plouf, 1f);
    }

}
