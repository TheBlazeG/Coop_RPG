using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : NetworkBehaviour
{   
    public PlayerList players;

    public List<object> combatants=new();
    private void Start()
    {
        
    }
    
    private void Update()
    {
        if (players.Player2 !=null)
        {
            //add enemy
            combatants.Add(players.Player1);
            combatants.Add(players.Player2);
            
        }
    }
    
}
