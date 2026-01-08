using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class PlayerGamepadManager : MonoBehaviour
{

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    public Dictionary<InputDevice, PlayerInput> lajaladaEsa = new Dictionary<InputDevice, PlayerInput>();

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Disconnected)
        {
            Debug.Log("ya valió");
            
        } else if (change == InputDeviceChange.Reconnected)
        {
            PlayerInput play = lajaladaEsa[device];
            if (play!= null)
            {
                play.gameObject.GetComponent<Playah>().myActions.devices = play.devices.ToArray();
            }
        }
    }
}
