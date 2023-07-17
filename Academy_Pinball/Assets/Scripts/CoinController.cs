using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Collider ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            CoinDespawner();
        }
    }

    public void CoinSpawned()
    {
        this.gameObject.SetActive(true);
        AutoCoinDespawner();
    }

    public void AutoCoinDespawner()
    {
        StartCoroutine(WaitUntilDespawn(10));
    }

    public void CoinDespawner()
    {
        this.gameObject.SetActive(false);
        FindAnyObjectByType<CoinManager>().DecreaseTotalSpawned();
    }

    private IEnumerator WaitUntilDespawn(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("Despawn " + gameObject.name);
        CoinDespawner();
    }
}
