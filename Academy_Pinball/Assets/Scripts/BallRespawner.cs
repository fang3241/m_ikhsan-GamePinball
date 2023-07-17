using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    public BallController ball;

    private void OnTriggerEnter(Collider other)
    {
        if(other == ball.GetComponent<Collider>())
        {
            ball.Respawn();
        }
    }
}
