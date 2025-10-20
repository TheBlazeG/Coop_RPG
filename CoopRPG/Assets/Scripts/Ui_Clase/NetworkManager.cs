using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager singleton;
    public static NetworkManager Instance => singleton;

    public NetworkRunner runner;

    private void Awake()
    {
        if (singleton !=null &&singleton !=this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }

    public async void StartGame()
    {
        NetworkSceneInfo sceneInfo = new NetworkSceneInfo();
        sceneInfo.AddSceneRef(SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex), LoadSceneMode.Additive);
        StartGameArgs args = new StartGameArgs()
        {
           GameMode= GameMode.Shared,
            SessionName="skibidi de "+ PlayerInfo.instance.username,
            Scene =sceneInfo,
            SceneManager = runner.GetComponent<NetworkSceneManagerDefault>()
        };

        Debug.Log("viendo si jala jefe");
        await runner.StartGame(args);
        Debug.Log("Si jala jefe");
    }
}
