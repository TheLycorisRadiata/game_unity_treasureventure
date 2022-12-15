using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGrateController : MonoBehaviour
{
    // NOTE: The script is currently added to the "SD_Trap_SpikeGrate_02" game object (not the prefab)

    //private PlayerHealthManager playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();

    private static GameObject player;
    private PlayerHealthManager playerHealthManager;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If other is Player
        if (other.gameObject.CompareTag("Player"))
        {
            Hit();
        }
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(2f);
        //player.DisablePhysics();
        playerHealthManager.DisablePhysics();

        //boxCollider.isTrigger = true;
    }
}
