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

    private void Awake(){
        inactivePosition = gameObject.transform.position;
        activePosition = new Vector3(inactivePosition.x, inactivePosition.y + 3f, inactivePosition.z);
        activationSpeed = 20f;
        desactivationSpeed = 0.3f;
        opened = false;
        activated= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            // TODO: coroutine Delay ne marche pas
            StartCoroutine(Delay(2f));
            if (transform.position == inactivePosition)
                StartCoroutine(LerpCoroutineToEnd());
        }
        if (opened)
        {
            // TODO: coroutine Delay ne marche pas
            StartCoroutine(Delay(5f));
            if (transform.position == activePosition)
                StartCoroutine(LerpCoroutineToStart());
        }
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

    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
