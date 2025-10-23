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
            GameObject.Find("CombatAndTurnManager").TryGetComponent<Rpg_Combat_Menu>(out Rpg_Combat_Menu combat);
            combat.localPlayer = player;
            if(player.AsIndex ==1)
            {
                GameObject.Find("CombatAndTurnManager").TryGetComponent<PlayerList>(out PlayerList list);
                list.Player1 = player;
            }
            else
            {
                GameObject.Find("CombatAndTurnManager").TryGetComponent<PlayerList>(out PlayerList list);
                list.Player2= player;
            }
        }
    }
}
