using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material switchOn;
    public Material switchOff;

    public bool isOn;

    private SwitchState state;
    public Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
        Set(false);

        StartCoroutine(StartBlinkTimer(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Debug.Log("kena switch");
            Toggle();
            
        }
    }

    private void Set(bool active)
    {
        isOn = active;

        if (isOn)
        {
            state = SwitchState.On;
            ren.material = switchOn;
            
        }
        else
        {

            state = SwitchState.Off;
            ren.material = switchOff;
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        
        for(int i = 0; i < times; i++)
        {
            ren.material = switchOn;
            yield return new WaitForSeconds(0.5f);
            ren.material = switchOff;
            yield return new WaitForSeconds(0.5f);

        }

        state = SwitchState.Off;
        StartCoroutine(StartBlinkTimer(5));
    }

    private IEnumerator StartBlinkTimer(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
