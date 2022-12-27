using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGrateTrap : MonoBehaviour
{
    private static AudioManager am;
    private static Sound[] arrSounds;
    private Transform spikes;
    private Vector3 activePosition, inactivePosition;
    private bool activated;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        arrSounds = new Sound[3];
        arrSounds[0] = am.AddAudioSource("TrapTriggered", gameObject);
        arrSounds[1] = am.AddAudioSource("SpikeTrapMovement", gameObject);
        arrSounds[2] = am.AddAudioSource("SpikeGrateTrapPulledBackDown", gameObject);

        spikes = transform.Find("Spikes");
    }

    void Start()
    {
        inactivePosition = spikes.position;
        activePosition = new Vector3(inactivePosition.x, inactivePosition.y + 5f, inactivePosition.z);
        activated = false;
    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (!activated && collision.gameObject.CompareTag("Player"))
        {
            am.Play(Array.Find(arrSounds, item => item.name == "TrapTriggered"), "TrapTriggered");
            yield return new WaitForSeconds(0.5f);
            am.Play(Array.Find(arrSounds, item => item.name == "SpikeTrapMovement"), "SpikeTrapMovement");
            activated = true;
        }
    }

    private IEnumerator OnCollisionExit(Collision collision)
    {
        if (activated && collision.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(5f);
            am.Play(Array.Find(arrSounds, item => item.name == "SpikeGrateTrapPulledBackDown"), "SpikeGrateTrapPulledBackDown");
            activated = false;
            yield return new WaitForSeconds(9.5f);
            am.Stop(Array.Find(arrSounds, item => item.name == "SpikeGrateTrapPulledBackDown"), "SpikeGrateTrapPulledBackDown");
        }
    }

    void Update()
    {
        if (activated && spikes.position != activePosition)
            StartCoroutine(LerpCoroutineToActive());
        else if (!activated && spikes.position != inactivePosition)
            StartCoroutine(LerpCoroutineToInactive());
    }

    private IEnumerator LerpCoroutineToActive()
    {
        float time = 0f;
        float activationSpeed = 15f;

        while (spikes.position != activePosition)
        {
            spikes.position = Vector3.Lerp(inactivePosition, activePosition, (time / Vector3.Distance(inactivePosition, activePosition)) * activationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator LerpCoroutineToInactive()
    {
        float time = 0f;
        float deactivationSpeed = 0.5f;

        while (spikes.position != inactivePosition)
        {
            spikes.position = Vector3.Lerp(activePosition, inactivePosition, (time / Vector3.Distance(activePosition, inactivePosition)) * deactivationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
