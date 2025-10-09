using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public TrafficLight trafficLight;
    public static ObjectManager singleton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        singleton = this;
    }
}
