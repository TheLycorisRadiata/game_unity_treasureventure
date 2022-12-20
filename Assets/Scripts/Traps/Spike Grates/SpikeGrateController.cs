using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGrateController : MonoBehaviour
{
    private static GameObject spike;
    private SpikeController spikeController;

    void Awake()
    {
        spike = transform.Find("Spikes").gameObject;
        spikeController = spike.GetComponent<SpikeController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if(!spikeController.opened)
                spikeController.activated = true;
    }

}
