using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDrawer : MonoBehaviour
{
    public Color color;
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * 10, color, 5);
        Debug.Log(transform.right);
    }
}
