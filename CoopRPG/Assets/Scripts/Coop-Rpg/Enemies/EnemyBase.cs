using Fusion;
using UnityEngine;

public class EnemyBase : NetworkBehaviour
{
    public int hp { get; private set; }
    public int speed { get; private set; }
    public int defense { get; private set; }
    public int attack { get; private set; }


    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public virtual void RPC_Attack()
    {
        Debug.Log("enemy Attack");
    }
}
