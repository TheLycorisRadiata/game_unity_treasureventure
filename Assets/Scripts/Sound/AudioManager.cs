using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public AudioMixer audioMixer;
	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;

	void Awake()
	{
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

		foreach (Sound s in sounds)
		{
			if (!s.sourceIsCamera)
				continue;
			s.source = camera.AddComponent<AudioSource>();
			s.source.outputAudioMixerGroup = s.mixerGroup != null ? s.mixerGroup : mixerGroup;
			s.source.clip = s.clip;
			s.source.playOnAwake = s.playOnAwake;
			s.source.loop = s.loop;
			s.source.spatialBlend = s.spatialBlend;
			s.source.maxDistance = s.maxDistance;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

	public Sound AddAudioSource(string sound, GameObject go)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return null;
		}

		s.source = go.AddComponent<AudioSource>();
		s.source.outputAudioMixerGroup = s.mixerGroup != null ? s.mixerGroup : mixerGroup;
		s.source.clip = s.clip;
		s.source.playOnAwake = s.playOnAwake;
		s.source.loop = s.loop;
		s.source.spatialBlend = s.spatialBlend;
		s.source.maxDistance = s.maxDistance;
		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		return s;
	}

	public void Play(Sound objSound, string sound)
	{
		Sound s;

		if (objSound != null)
			s = objSound;
		else
		{
			s = Array.Find(sounds, item => item.name == sound);
			if (s == null)
			{
				Debug.LogWarning("Sound: " + sound + " not found!");
				return;
			}
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.Play();
	}

	public void Stop(Sound objSound, string sound)
	{
		Sound s;

		if (objSound != null)
			s = objSound;
		else
		{
			s = Array.Find(sounds, item => item.name == sound);
			if (s == null)
			{
				Debug.LogWarning("Sound: " + sound + " not found!");
				return;
			}
		}

		s.source.Stop();
	}

	public int SetMixerVolume(int indexOption, int input)
	{
		string group = indexOption == 1 ? "MusicVolume" : indexOption == 2 ? "AmbienceVolume" : indexOption == 3 ? "EffectsVolume" : "MasterVolume";
		float currVolume = 0f;
		bool result = audioMixer.GetFloat(group, out currVolume);
		int percentage = 0;

		// "currVolume": 0f (100%) / -80f (0%)
		// 1% is 0.8

		// Compensate for floating point imprecision
		if (currVolume > 0f) currVolume = 0f;
		else if (currVolume < -80f) currVolume = -80f;

		// The rounding is around "currVolume / 0.8f" for the same reason
		percentage = 100 + (int)Math.Round(currVolume / 0.8f, 0);

		if (input == 1)
		{
			if (percentage == 100)
			{
				Play(null, "MenuLimit");
				return -1;
			}

			Play(null, "MenuForward");
		}
		else if (input == -1)
		{
			if (percentage == 0)
			{
				Play(null, "MenuLimit");
				return -1;
			}

			Play(null, "MenuBack");
		}
		else
		{
			Play(null, "Error");
			return -1;
		}

		// Update percentage
		percentage += input;

		// Update volume
		currVolume = (percentage - 100) * 0.8f;
		audioMixer.SetFloat(group, currVolume);

		return percentage;
	}
}
