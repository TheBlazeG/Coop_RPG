using Fusion;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPosition;

    public GameObject particles;

    private InputActions inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        bool foo = inputActions.Player.Shoot.triggered;

        if (HasInputAuthority && foo)
        {
            Rpc_ShootAShot();
        }
    }

    // Update is called once per frame
    [Rpc(RpcSources.InputAuthority,RpcTargets.StateAuthority)]
    private void Rpc_ShootAShot()
    {
        var blt = Runner.Spawn(bulletPrefab, shootPosition.position, shootPosition.rotation, Object.InputAuthority);

        if (blt.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(blt.transform.forward * 6, ForceMode.Impulse);
        }
    }
}
