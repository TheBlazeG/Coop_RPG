using UnityEngine;
using Fusion;
using TMPro;

public class PlayerSpawnerRPG : SimulationBehaviour, IPlayerJoined
{
    public GameObject[] playerPrefab;
    public Transform[] playerSpawners;
    public TextMeshProUGUI playerText;
    public GameObject combatUI;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Debug.Log(player.AsIndex);
            
            
                Runner.Spawn(playerPrefab[player.AsIndex-1], playerSpawners[player.AsIndex-1].position, Quaternion.identity, player);
                playerText.text = "Player " +player.AsIndex;
                combatUI.SetActive(true);
        }
    }
}
