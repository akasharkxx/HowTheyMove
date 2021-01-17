using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animatorInThisObject;
    private int isWalkingHash;
    private int isRunningHash;

    private void Start()
    {
        animatorInThisObject = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        bool isWalking = animatorInThisObject.GetBool(isWalkingHash);
        bool isRunning = animatorInThisObject.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runningPressed = Input.GetKey(KeyCode.LeftShift);

        if (!isWalking && forwardPressed)
        {
            animatorInThisObject.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animatorInThisObject.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runningPressed))
        {
            animatorInThisObject.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runningPressed))
        {
            animatorInThisObject.SetBool(isRunningHash, false);
        }
    }
}
