using UnityEngine;
using System.Collections;

public class DialogAudio
{
	public AudioClip soundClip;

	public ArrayList soundClips;

	public float minPitch;
	public float maxPitch;

	public DialogAudio(AudioClip clip, float min, float max)
	{
		soundClip = clip;
		minPitch = min;
		maxPitch = max;
		soundClips = new ArrayList ();

	}

	public DialogAudio( float min, float max)
	{
		minPitch = min;
		maxPitch = max;
		soundClips = new ArrayList ();
	}

	public void addSoundClip(AudioClip audio)
	{
		soundClips.Add (audio);
	}

	public AudioClip getRandomClip()
	{
		return (AudioClip) soundClips[ Random.Range (0, soundClips.Count)];
	}

}