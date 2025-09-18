using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelloRPC : NetworkBehaviour
{
    [Rpc(RpcSources.InputAuthority,RpcTargets.All)]
    public void RPC_SayOWO(string msg, RpcInfo info = default)
    {
        Debug.Log(info.Source+ " Says: " + msg);
    }

    private void Update()
    {
        if (Object.HasInputAuthority && Mouse.current.rightButton.wasPressedThisFrame)
        {
            RPC_SayOWO("OWO");
        }
    }
}
