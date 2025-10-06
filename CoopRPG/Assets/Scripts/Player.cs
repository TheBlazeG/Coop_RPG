using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private InputActions inputActions;
    bool eggpain = false;
    bool fayah = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!eggpain)
        {
            eggpain = inputActions.Player.Action.triggered;
        }

        if (!fayah)
        {
            fayah = inputActions.Player.Shoot.triggered;
        }
    }
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if (Object.HasInputAuthority && eggpain == true)
        {
            eggpain = false;
            RPC_CallTraficLight();
        }
        if (Object.HasInputAuthority && fayah == true)
        {
            fayah = false;
            Rpc_ShootAShot();
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_CallTraficLight()
    {
        ObjectManager.singleton.trafficLight.ChangeColor();
    }
    #region PewPew
    public GameObject bulletPrefab;
    public Transform shootPos;

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void Rpc_ShootAShot()
    {
        var bullet = Runner.Spawn(bulletPrefab, shootPos.position, shootPos.rotation, Object.InputAuthority);

        if (bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(bullet.transform.forward * 3, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("yo cuando no tengo cuerpo");
        }
    }
    #endregion

}
