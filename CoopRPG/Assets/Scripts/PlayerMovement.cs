using UnityEngine;
using Fusion;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    private CharacterController characterController;
    public float speed;

    void Start()
    {
        gameObject.TryGetComponent(out characterController);
    }

    
   public override void FixedUpdateNetwork()
    {
        Vector3 move = new Vector3(0,0,0)*Runner.DeltaTime * speed;

        characterController.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
