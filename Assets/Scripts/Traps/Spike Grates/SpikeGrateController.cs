using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class SpikeGrateController : MonoBehaviour
{
    private static GameObject player;
    private static GameObject spike;
    //private PlayerHealthManager playerHealthManager;
    //private PlayerController playerController;
    private SpikeController spikeController;
    private Rigidbody spikeRigidBody;

    void Awake()
    {
        // Player component references
        player = GameObject.FindGameObjectWithTag("Player");
        //playerController = player.GetComponent<PlayerController>();
        //playerHealthManager = player.GetComponent<PlayerHealthManager>();
        // Spike component references
        spike = transform.Find("Spikes").gameObject;
        spikeController = spike.GetComponent<SpikeController>();
        spikeRigidBody = spike.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if(!spikeController.opened)
                spikeController.activated = true;
    }

}
