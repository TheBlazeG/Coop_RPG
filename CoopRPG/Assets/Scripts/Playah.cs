using UnityEngine;
using UnityEngine.InputSystem;

public class Playah : MonoBehaviour
{
    public InputActions myActions;

    private void Start()
    {
        myActions = new InputActions();
        myActions.Enable();
        myActions.Player.Enable();
        myActions.devices = gameObject.GetComponent<PlayerInput>().devices.ToArray();
    }
}
