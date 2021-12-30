using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        float dist = (target.position - transform.parent.position).magnitude;
        float diff = dist - transform.localPosition.x;
        float denom = Mathf.Sqrt(Mathf.Pow(dist, 2) - 2 * dist * transform.localPosition.x +
                                 Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow(transform.localPosition.y, 2));
        float rotation = Mathf.Acos(diff / denom) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
