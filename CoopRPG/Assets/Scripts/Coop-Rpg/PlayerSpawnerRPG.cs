using UnityEngine;
using Fusion;

public class PlayerSpawnerRPG : SimulationBehaviour, IPlayerJoined
{
    public GameObject[] playerPrefab;
    public Transform[] playerSpawners;
    [Networked]
    int playerIndex { get; set; } = 0;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Debug.Log(playerIndex);
            Runner.Spawn(playerPrefab[playerIndex], playerSpawners[playerIndex].position,Quaternion.identity,player);
            playerIndex++;
        }
    }
}
