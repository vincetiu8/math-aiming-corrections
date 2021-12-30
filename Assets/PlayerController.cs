using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform body;
    public Transform head;
    public Transform wand;
    public Transform target;

    private void Update()
    {
        Vector3 targetPos = target.position;
        Vector3 bodyPos = body.position;
        float yRot = Mathf.Atan2(targetPos.x - bodyPos.x, targetPos.z - bodyPos.z) * Mathf.Rad2Deg;
        body.rotation = Quaternion.Euler(0, yRot, 0);
        
        Vector3 displacement = targetPos - wand.parent.position;
        float yDist = Mathf.Sqrt(Mathf.Pow(displacement.x, 2) + Mathf.Pow(displacement.z, 2));

        Vector3 headPos = head.position;
        float xRotHead = Mathf.Atan2( headPos.y - targetPos.y, yDist) * Mathf.Rad2Deg;
        head.localRotation = Quaternion.Euler(xRotHead, 0, 0);

        Vector3 wandPos = wand.position;
        Vector3 wandLocalPos = wand.localPosition;

        Vector3 displacementXZ = targetPos - wandPos;
        float xzDist = Mathf.Sqrt(Mathf.Pow(displacementXZ.x, 2) + Mathf.Pow(displacementXZ.z, 2));
        float xRotWand = Mathf.Atan2(wandPos.y - targetPos.y, xzDist) * Mathf.Rad2Deg;
        float numerator = yDist - wandLocalPos.z;
        float denominator = Mathf.Sqrt(Mathf.Pow(yDist, 2) - 2 * yDist * wandLocalPos.z + Mathf.Pow(wandLocalPos.z, 2) +
                                       Mathf.Pow(wandLocalPos.x, 2));
        float yAdj = Mathf.Acos(numerator / denominator) * Mathf.Rad2Deg;
        wand.localRotation = Quaternion.Euler(xRotWand, -yAdj, 0);
    }
}
