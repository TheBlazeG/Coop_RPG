using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : NetworkBehaviour
{
    [Networked]
    public PlayerRef Player1 { get; set; }

    [Networked, OnChangedRenderAttribute(nameof(CallRPCCombatMenu))]
    public PlayerRef Player2 { get; set; }
    public PlayerRef player2Proxy;

    public bool bothPlayersSpawned = false;

    public override void Spawned()
    {
        Player2 = player2Proxy;
        if (Player2 == PlayerRef.None)
        {
            return;
        }

        
        RPC_ActivateCombatMenu(Player2);
        Debug.Log("My player is now " + Player2);
    }

    void CallRPCCombatMenu()
    {
        Debug.Log("changedrender called");
        //RPC_ActivateCombatMenu();
    }

    [Rpc(RpcSources.All,RpcTargets.All)]
    void RPC_ActivateCombatMenu(PlayerRef elTwo) 
    {
        Player2 = elTwo;
        TurnSystem combat = GameObject.FindAnyObjectByType<TurnSystem>();
        combat.enabled = true;
        Debug.Log($"Player 1 = {Player1} and the other guy is {Player2}");
    }
}
