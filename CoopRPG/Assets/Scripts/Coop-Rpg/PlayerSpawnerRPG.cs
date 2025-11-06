using UnityEngine;
using Fusion;
using TMPro;

public class PlayerSpawnerRPG : SimulationBehaviour, IPlayerJoined
{
    public GameObject[] playerPrefab;
    public Transform[] playerSpawners;
    public TextMeshProUGUI playerText;
    public GameObject combatUI;
    public Rpg_Combat_Menu combatMenu;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Debug.Log(player.AsIndex);
            
            
            GameObject spawnedPlayer =Runner.Spawn(playerPrefab[player.AsIndex-1], playerSpawners[player.AsIndex-1].position, Quaternion.identity, player).gameObject;
                playerText.text = "Player " +player.AsIndex;
                combatUI.SetActive(true);
            combatMenu.localPlayerId = player;
            if(player.AsIndex ==1)
            {
                GameObject.Find("CombatAndTurnManager").TryGetComponent<PlayerList>(out PlayerList list);
                Debug.Log(combatMenu);
                combatMenu.localPlayer= spawnedPlayer.GetComponent<PlayerRPG>();
                list.Player1 = player;
            }
            if(player.AsIndex ==2)
            {
                combatMenu.gameObject.TryGetComponent<PlayerList>(out PlayerList list);
                combatMenu.localPlayer = spawnedPlayer.GetComponent<PlayerRPG>();
                Debug.Log("Before Stuff");
                list.player2Proxy= player;
                //Debug.Log("After player is : " + list.Player2);

            }
        }
    }

   
    
}
