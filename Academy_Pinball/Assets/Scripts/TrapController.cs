using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public Collider ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            ball.GetComponent<BallController>().Respawn();
            TrapDespawner();
        }
    }

    public void TrapSpawned()
    {
        this.gameObject.SetActive(true);
        AutoTrapDespawner();
    }

    public void AutoTrapDespawner()
    {
        StartCoroutine(WaitUntilDespawn(10));
    }

    public void TrapDespawner()
    {
        this.gameObject.SetActive(false);
        FindAnyObjectByType<TrapManager>().DecreaseTotalSpawned();
        
    }

    private IEnumerator WaitUntilDespawn(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("Despawn " + gameObject.name);
        TrapDespawner();
    }
}
