using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;
    public List<Transform> players;
    public List<Vector2> screenPositions= new List<Vector2>();

    public Camera mergeCamera;

    private void Update()
    {
        int i = 0;
        foreach (var player in players)
        {
            screenPositions[i] = ProjectToViewport(player);
            i++;
        }
    }

    private Vector2 ProjectToViewport(Transform player)
    {
        Vector3 v = mergeCamera.WorldToViewportPoint(transform.position);
        return new Vector2(Mathf.Clamp01(v.x),Mathf.Clamp01(v.y));
    }

    private void OnDrawGizmos()
    {
        foreach (var position in screenPositions)
        {
            var v = mergeCamera.ViewportToWorldPoint(new Vector3(position.x, position.y, mergeCamera.nearClipPlane + 1));
            Gizmos.DrawSphere(v, 0.05f);
        }
    }
}