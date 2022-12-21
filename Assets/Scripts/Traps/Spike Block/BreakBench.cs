using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBench : MonoBehaviour
{
    [SerializeField]
    private GameObject brokenVersionPrefab;

    void OnCollisionEnter(Collision collision)
    {
        GameObject brokenVersion;

        if (collision.gameObject.name.Contains("SpikeBlock"))
        {
            brokenVersion = Instantiate(brokenVersionPrefab, transform.position, transform.rotation);
            brokenVersion.transform.SetParent(gameObject.transform.parent);
            Destroy(gameObject);
        }
    }
}
