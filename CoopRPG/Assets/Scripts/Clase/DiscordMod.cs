using Fusion;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiscordMod : MonoBehaviour
{
    public static DiscordMod Instance;
    private Dictionary<PlayerRef,NetworkObject> playersDic = new Dictionary<PlayerRef,NetworkObject>();


    private void Awake() => Instance = this;

    public bool TryGetPlayah(PlayerRef playerRef,out NetworkObject netobj)
    {
 if (playersDic.ContainsKey(playerRef))
        {
            netobj = playersDic[playerRef];
            return true;
        }
        else
        {
            netobj = null;
            return false;
        }
    }
    public bool TryAddPlayah(PlayerRef playerRef,NetworkObject netobj)
    {
        if (!playersDic.ContainsKey(playerRef))
        {
            playersDic[playerRef] = netobj;
            return true;
        }
        else
        {
            playersDic.Add(playerRef, netobj);
            return false;
        }
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            foreach (var player in playersDic)
            {
                Debug.Log("Player: " + player.Key + " is at" + player.Value.transform.position);
            }
        }
    }

    public void MandaALVPlayer(PlayerRef playerRef)
    {
        if (playersDic.ContainsKey(playerRef))
        {
            playersDic.Remove(playerRef);
        }
    }
}
