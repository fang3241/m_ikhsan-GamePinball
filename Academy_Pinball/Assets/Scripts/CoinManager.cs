using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public CoinController[] coins;

    public int maxSpawned;
    public float spawnTime;
    public int totalSpawned;

    // Start is called before the first frame update
    void Start()
    {
        totalSpawned = 0;

        foreach(CoinController coin in coins)
        {
            coin.gameObject.SetActive(false);
        }

        StartCoroutine(SpawnTimer(spawnTime));
    }
    
    public void DecreaseTotalSpawned()
    {
        totalSpawned--;
    }

    public void SpawnCoin()
    {
        int rand = Random.Range(0, coins.Length);
        bool spawned = false;

        if(totalSpawned < maxSpawned)
        {
            while (!spawned)
            {
                if (coins[rand].gameObject.activeSelf)
                {
                    rand = Random.Range(0, coins.Length);
                }
                else
                {
                    spawned = true;
                    coins[rand].CoinSpawned();
                    totalSpawned++;
                    Debug.Log("Coin spawned " + coins[rand].name);
                }
            }
        }

        StartCoroutine(SpawnTimer(spawnTime));
        
    }

    public IEnumerator SpawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnCoin();

    }
}
