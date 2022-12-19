using System.Collections;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private Vector3 activePosition;
    private Vector3 inactivePosition;
    [SerializeField] float activationSpeed;
    [SerializeField] float desactivationSpeed;
    public bool activated;
    public bool opened;
    private PlayerHealthManager playerHealthManager;

    private void Awake()
    {
        inactivePosition = gameObject.transform.position;
        activePosition = new Vector3(inactivePosition.x, inactivePosition.y + 3f, inactivePosition.z);
        activationSpeed = 20f;
        desactivationSpeed = 0.3f;
        opened = false;
        activated = false;
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    void Update()
    {
        if (activated)
            StartCoroutine(StartDelay2s());
        if (opened)
            StartCoroutine(EndDelay5s());
    }

    private IEnumerator LerpCoroutineToEnd()
    {
        float time = 0f;
        while (transform.position != activePosition)
        {
            transform.position = Vector3.Lerp(inactivePosition, activePosition, (time / Vector3.Distance(inactivePosition, activePosition)) * activationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        activated = false;
        opened = true;
    }

    private IEnumerator LerpCoroutineToStart()
    {
        float time = 0f;
        while (transform.position != inactivePosition)
        {
            transform.position = Vector3.Lerp(activePosition, inactivePosition, (time / Vector3.Distance(activePosition, inactivePosition)) * desactivationSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        opened = false;
    }

    IEnumerator StartDelay2s()
    {
        yield return new WaitForSeconds(2f);
        if (transform.position == inactivePosition)
            StartCoroutine(LerpCoroutineToEnd());
    }

    IEnumerator EndDelay5s()
    {
        yield return new WaitForSeconds(5f);
        if (transform.position == activePosition)
            StartCoroutine(LerpCoroutineToStart());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Damage player
                playerHealthManager.RemoveLifePoints(20);
            }
        }
    }
}