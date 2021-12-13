using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : LocalManager<SoundManager>
{
    private AudioSource audioSource = null;
    public List<AudioClip> clips = null;

    protected override void Awake()
    {
	base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    private void Play(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay);
    }

	public void PlayGoodNote()
	{
		Play(clips[0]);
	}

	public void PlayLaunchMissile()
	{
		Play(clips[1]);
	}

	public void PlaybossGruntLight()
	{
		Play(clips[2]);
	}

	public void PlayexplosionLight()
	{
		Play(clips[3]);
	}

	public void PlayPrelaser()
	{
		Play(clips[4]);
	}

	public void PlaybossAttacks2()
	{
		Play(clips[5]);
	}

	public void PlayLaunchLaser()
	{
		Play(clips[6]);
	}

	public void PlaybossAttacks()
	{
		Play(clips[7]);
	}

	public void PlayperfectNote()
	{
		Play(clips[8]);
	}

	public void PlayplayerGetsHit()
	{
		Play(clips[9]);
	}

	public void PlaymissNote()
	{
		Play(clips[10]);
	}
}