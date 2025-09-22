using UnityEngine;
using Fusion;

public class TrafficLight : NetworkBehaviour
{
    private MeshRenderer mr;
    public int index = 0;
    public Color[] colors = { Color.green, Color.yellow, Color.red };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.TryGetComponent(out mr);
    }

    // Update is called once per frame
    public void ChangeColor()
    {
        index = (index + 1) % colors.Length;
        mr.material.color =colors[index];
    }
}
