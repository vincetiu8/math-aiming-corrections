using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class FollowMouse : MonoBehaviour
{
    public float rotateSpeed;
    public float translateSpeed;
    public float avgDist;
    public float distAmp;
    
    private float deg;
    private float dist;

    private void Update()
    {
        deg += rotateSpeed * Time.deltaTime;
        dist = avgDist + distAmp * Mathf.Sin(translateSpeed * Time.time * Mathf.Deg2Rad);
        transform.position = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad) * dist,Mathf.Sin(deg * Mathf.Deg2Rad) * dist,transform.position.z);
    }

    public void Follow(InputAction.CallbackContext context)
    {
        // Vector2 newPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        // transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
