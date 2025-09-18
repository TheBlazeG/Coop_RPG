using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorNetworked : NetworkBehaviour
{
    private MeshRenderer mr;
    [Networked, OnChangedRenderAttribute(nameof(ShainBrightLaikADiamond))]
    public Color color {  get;  set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gameObject.TryGetComponent(out mr);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            color = Random.ColorHSV();
        }
    }

    private void ShainBrightLaikADiamond()
    {
        mr.material.color = color;
    }

}
