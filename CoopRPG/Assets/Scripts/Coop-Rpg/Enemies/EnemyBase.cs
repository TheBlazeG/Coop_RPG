using Fusion;
using UnityEngine;

public class EnemyBase : NetworkBehaviour
{
    public int hp { get; private set; }
    public int speed;
    public int defense { get; private set; }
    public int attack { get; private set; }


    private void Start()
    {
        GameObject.FindAnyObjectByType<TurnSystem>().combatants.Add(this);
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public virtual void RPC_Attack()
    {
        Debug.Log("enemy Attack");
    }
}
