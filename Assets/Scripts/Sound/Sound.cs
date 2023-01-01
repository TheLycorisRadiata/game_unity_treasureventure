using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioMixerGroup mixerGroup;
	public AudioClip clip;

	public bool playOnAwake = false;
	public bool loop = false;
	public float spatialBlend = 1f;
	public float maxDistance = 10f;

	[HideInInspector]
	public AudioSource source;
	public bool sourceIsCamera = false;

	[Range(0f, 1f)]
	public float volume = .75f;
	[Range(0f, 1f)]
	public float volumeVariance = .1f;

	[Range(.1f, 3f)]
	public float pitch = 1f;
	[Range(0f, 1f)]
	public float pitchVariance = .1f;
}
