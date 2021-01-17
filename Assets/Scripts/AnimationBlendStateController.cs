using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBlendStateController : MonoBehaviour
{
    public float accelaration = 0.1f;
    public float deccelaration = 0.5f;

    private Animator animatorInThisObject;
    private float velocity;
    private int velocityHash;

    private void Start()
    {
        velocity = 0.0f;
        animatorInThisObject = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runningPressed = Input.GetKey(KeyCode.LeftShift);

        if(forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * accelaration;
        }

        if(!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deccelaration;
        }

        if(!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animatorInThisObject.SetFloat(velocityHash, velocity);
    }
}
