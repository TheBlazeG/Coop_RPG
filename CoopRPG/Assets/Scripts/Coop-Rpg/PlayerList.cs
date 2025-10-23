using Fusion;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : NetworkBehaviour
{
    [Networked]
    public PlayerRef Player1 { get; set; }

    [Networked]
    public PlayerRef Player2 { get; set; }

    
}
