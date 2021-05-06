using UnityEngine;
using System;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private float yOffset = 0f;
    [SerializeField] private float yMaxValue = 0f;
    [SerializeField] private float yMinValue = 0f;
    
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        var cameraY = player.transform.position.y;
        cameraY = cameraY > 0 ? Math.Min(cameraY, yMaxValue) : Math.Max(cameraY , yMinValue);
        
        transform.position = new Vector3(0f, cameraY + yOffset, -10);
    }

}