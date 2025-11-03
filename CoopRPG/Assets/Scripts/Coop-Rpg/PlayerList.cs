using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : NetworkBehaviour
{
    [Networked]
    public PlayerRef Player1 { get; set; }

    [Networked, OnChangedRenderAttribute(nameof(RPC_ActivateCombatMenu))]
    public PlayerRef Player2 { get; set; }

    public bool bothPlayersSpawned = false;

    [Rpc(RpcSources.All,RpcTargets.All)]
    void RPC_ActivateCombatMenu() 
    {
        Rpg_Combat_Menu combat = GameObject.FindAnyObjectByType<Rpg_Combat_Menu>();
        combat.enabled = true;
    }
}
