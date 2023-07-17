using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode keyInput;
    private HingeJoint hinge;

    private float targetPressed;
    private float targetReleased;


    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetReleased = hinge.limits.min;
    }

    private void Update()
    {
        readInput();
    }

    private void readInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(keyInput))
        {
            //Debug.Log("pressed");
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }

        hinge.spring = jointSpring;
    }

}
