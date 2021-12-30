using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector2 v = target.position - transform.position;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(v.y, v.x)* Mathf.Rad2Deg, Vector3.forward);
    }
}
