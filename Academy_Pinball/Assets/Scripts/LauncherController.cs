using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxForce;
    public float maxTimeHold;

    public Material idleMat;
    public Material holdMat;

    private bool isHold = false;

    
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == bola)
        {
            //Debug.Log("Bola ready");
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input))
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;

        float timeHold = 0.0f;

        Renderer ren = GetComponent<Renderer>();

        while (Input.GetKey(input))
        {
            ren.material = holdMat;
            
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);
            Debug.Log(force);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);

        isHold = false;
        ren.material = idleMat;
    }
}
