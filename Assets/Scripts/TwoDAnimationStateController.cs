using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDAnimationStateController : MonoBehaviour
{
    public float acceleration = 2.0f;
    public float decceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    private Animator animatorOnModel;
    private float velocityZ = 0.0f;
    private float velocityX = 0.0f;
    private int VelocityZHash;
    private int VelocityXHash;

    private void Start()
    {
        animatorOnModel = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        LockAndResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);

        animatorOnModel.SetFloat(VelocityZHash, velocityZ);
        animatorOnModel.SetFloat(VelocityXHash, velocityX);
    }

    private void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        //Forward movement
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        //Left movement
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //Right movement
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if(backPressed && velocityZ > -maximumWalkVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration; 
        }

        //applying decceleration in forward is W not pressed
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decceleration;
        }

        //Decceleartion in Left movement is A not pressed
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decceleration;
        }

        //Decceleartion in Right movement is D not pressed
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * decceleration;
        }

        if(!backPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * decceleration;
        }
    }

    private void LockAndResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        //Reset velocityZ
        if (!forwardPressed && !backPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0f;
        }

        //Reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        //Clamp velocityZ
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * decceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity - 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }
        //end

        //VelocityX for left
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * decceleration;
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity + 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
        //end

        //VelocityX for right
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * decceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity - 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
        //end

        //VelocityZ for back
        if (backPressed && velocityZ < -maximumWalkVelocity)
        {
            velocityZ += Time.deltaTime * decceleration;
            if (velocityZ < -maximumWalkVelocity && velocityZ > (-maximumWalkVelocity + 0.05f))
            {
                velocityZ = -maximumWalkVelocity;
            }
        }
        else if (backPressed && velocityZ > maximumWalkVelocity && velocityZ < (maximumWalkVelocity - 0.05f))
        {
            velocityZ = maximumWalkVelocity;
        }
    }
}
