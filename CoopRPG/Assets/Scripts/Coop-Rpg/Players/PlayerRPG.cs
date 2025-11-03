using Fusion;
using UnityEngine;

public class PlayerRPG : NetworkBehaviour
{
    public int hp {  get; private set; }
    public int speed {  get; private set; }
    public int defense { get; private set; }
    public int attack { get; private set; }

    Rigidbody rb;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        rb.AddForce(0, 10, 0, ForceMode.Impulse);
    }

    [Rpc(RpcSources.InputAuthority,RpcTargets.All)]
    public virtual void RPC_SecondaryDefense()
    {}
    [Rpc(RpcSources.InputAuthority,RpcTargets.All)]

    public virtual void RPC_TeammateDefense()
    {}
    [Rpc(RpcSources.InputAuthority,RpcTargets.All)]
    public virtual void RPC_Attack(PlayerRef player)
    {
        Debug.Log("Player "+player.AsIndex + " attack"); 
    }

}
