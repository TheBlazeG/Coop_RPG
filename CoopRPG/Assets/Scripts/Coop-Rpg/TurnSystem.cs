using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : NetworkBehaviour
{   
    public PlayerList players;

    public List<object> combatants=new();


    private void OnEnable()
    {
        combatants.Add(players.Player1);
                    combatants.Add(players.Player2);
    }
    private void Start()
    {
        
            
        
    }
    
    private void Update()
    {
        
    }
    
}
