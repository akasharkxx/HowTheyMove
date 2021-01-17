using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public CharacterController characterControllerOfPlayer;
    public Animator aniamtorOnPlayer;
    public float maxWalkVelocity = 3.0f;
    public float maxRunVelocity = 2.0f;
    public float gravityVelocity = 9.8f;

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

        Vector3 movePos = (transform.right * velocityX + transform.forward * velocityZ) * currentMaxVelocity * Time.deltaTime;
        Vector3 newMovePos = movePos + new Vector3(0f, gravityVelocity * Time.deltaTime,0f);

        characterControllerOfPlayer.Move(newMovePos);
    }
}
