using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public TrapController[] traps;

    public int maxSpawned;
    public float spawnTime;
    public int totalSpawned;

    // Start is called before the first frame update
    void Start()
    {
        totalSpawned = 0;

        foreach (TrapController trap in traps)
        {
            trap.gameObject.SetActive(false);
        }

        StartCoroutine(SpawnTimer(spawnTime));
    }

    public void DecreaseTotalSpawned()
    {
        totalSpawned--;
    }

    public void SpawnTrap()
    {
        int rand = Random.Range(0, traps.Length);
        bool spawned = false;

        if (totalSpawned < maxSpawned)
        {
            while (!spawned)
            {
                if (traps[rand].gameObject.activeSelf)
                {
                    rand = Random.Range(0, traps.Length);
                }
                else
                {
                    spawned = true;
                    traps[rand].TrapSpawned();
                    totalSpawned++;
                    Debug.Log("Trap spawned " + traps[rand].name);
                }
            }
        }

        StartCoroutine(SpawnTimer(spawnTime));

    }

    public IEnumerator SpawnTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnTrap();

    }
}
