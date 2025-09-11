using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProvider : SimulationBehaviour, INetworkRunnerCallbacks
{
    private InputActions playerActionMap;
    private bool done;

    private void Start()
    {
        if (Runner != null)
        {
            Initialize();
        }
    }

    private void Update()
    {
        if (!done && Runner != null)
        {
            Initialize();
        }
    }

    private void OnDisable()
    {
        Runner.RemoveCallbacks(this);
    }

    private void Initialize()
    {
        playerActionMap = new InputActions();
        playerActionMap.Player.Enable();
        Runner.AddCallbacks(this);
        done = true;
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        InputSystem.Update();
        var myInput = new MyInput();
        var playerActions = playerActionMap.Player;

        myInput.buttons.Set(MyButtons.Forward, playerActions.Move.ReadValue<Vector2>().y > 0);
        myInput.buttons.Set(MyButtons.Backward, playerActions.Move.ReadValue<Vector2>().y < 0);
        myInput.buttons.Set(MyButtons.Right, playerActions.Move.ReadValue<Vector2>().x > 0);
        myInput.buttons.Set(MyButtons.Left, playerActions.Move.ReadValue<Vector2>().x < 0);

        input.Set(myInput);
    }

    #region Ignorados
    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        throw new NotImplementedException();
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        throw new NotImplementedException();
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        throw new NotImplementedException();
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        throw new NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        throw new NotImplementedException();
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }
    #endregion
}

public struct MyInput : INetworkInput
{
    public NetworkButtons buttons;
    public Vector3 aimDirection;
}

enum MyButtons
{
    Forward = 0,
    Backward = 1,
    Left = 2,
    Right = 3,
}