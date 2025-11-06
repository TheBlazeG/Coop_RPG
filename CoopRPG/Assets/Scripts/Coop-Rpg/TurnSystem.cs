using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : NetworkBehaviour
{   
    public PlayerList players;
    public GameObject enemy;
    public List<object> combatants=new();


    private void OnEnable()
    {
        combatants.Add(players.Player1);
                    combatants.Add(players.Player2);
        foreach (var item in combatants)
        {
            Debug.Log(item);
        }
    }
    private void Start()
    {
        
            
        
    }
    
    private void Update()
    {
        
    }
    
}
