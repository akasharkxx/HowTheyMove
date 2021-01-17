using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Rigidbody rBodyOnPlayer;
    public Animator aniamtorOnPlayer;
    public float maxWalkVelocity = 3.0f;
    public float maxRunVelocity = 2.0f;

    private float velocityZ = 0.0f;
    private float velocityX = 0.0f;
    private int VelocityZHash, VelocityXHash;

    private void Start()
    {
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }

    private void Update()
    {
        velocityX = aniamtorOnPlayer.GetFloat(VelocityXHash);
        velocityZ = aniamtorOnPlayer.GetFloat(VelocityZHash);

        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;

        Vector3 movePos = (transform.right * velocityX + transform.forward * velocityZ) * currentMaxVelocity;
        Vector3 newMovePos = new Vector3(movePos.x, rBodyOnPlayer.velocity.y, movePos.z);

        rBodyOnPlayer.velocity = newMovePos;
    }
}
