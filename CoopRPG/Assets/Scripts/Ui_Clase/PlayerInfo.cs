using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo singleton { get; private set; }
    public static PlayerInfo instance=> singleton;

    public string username { get; private set; }

    private void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(this);
        }
        else 
        {
        singleton = this;
        }
    }

    public void SetUsername(string user)
    {
    username = user;
    }
}
