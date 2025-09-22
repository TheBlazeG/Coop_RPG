using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private InputActions inputActions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        bool foo = inputActions.Player.Action.ReadValue<float>() > 0;
        if (Object.HasInputAuthority && foo == true)
        {
            RPC_CallTraficLight();
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_CallTraficLight()
    {
        ObjectManager.singleton.trafficLight.ChangeColor();
    }
}
