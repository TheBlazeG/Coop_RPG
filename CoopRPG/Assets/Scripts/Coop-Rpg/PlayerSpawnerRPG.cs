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
            
            
            GameObject spawnedPlayer =Runner.Spawn(playerPrefab[player.AsIndex-1], playerSpawners[player.AsIndex-1].position, Quaternion.identity, player).gameObject;
                playerText.text = "Player " +player.AsIndex;
                combatUI.SetActive(true);
            GameObject.Find("CombatAndTurnManager").TryGetComponent<Rpg_Combat_Menu>(out Rpg_Combat_Menu combat);
            combat.localPlayerId = player;
            if(player.AsIndex ==1)
            {
                GameObject.Find("CombatAndTurnManager").TryGetComponent<PlayerList>(out PlayerList list);
                Debug.Log(combat);
                combat.localPlayer= spawnedPlayer.GetComponent<PlayerRPG>();
                list.Player1 = player;
            }
            else
            {
                GameObject.Find("CombatAndTurnManager").TryGetComponent<PlayerList>(out PlayerList list);
                combat.localPlayer = spawnedPlayer.GetComponent<PlayerRPG>();
                list.Player2= player;

            }
        }
    }

   
    
}
