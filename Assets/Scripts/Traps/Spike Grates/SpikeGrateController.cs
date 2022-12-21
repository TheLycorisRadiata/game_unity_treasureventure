using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGrateController : MonoBehaviour
{
    private static AudioManager am;
    private SpikeController spikeController;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        spikeController = transform.Find("Spikes").GetComponent<SpikeController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !spikeController.opened)
        {
            am.Play("TrapTriggered");
            spikeController.activated = true;
        }
    }
}
