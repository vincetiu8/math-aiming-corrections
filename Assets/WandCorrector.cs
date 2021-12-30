using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationMode
{
    Euler,
    Quaternion
}

public class WandCorrector : MonoBehaviour
{
    [SerializeField] private RotationMode rotationMode;
    
    [SerializeField] private Transform wand;
    private RaycastHit[] _hits;

    private void Awake()
    {
        _hits = new RaycastHit[1];
    }

    private void Update()
    {
        int numHits = Physics.RaycastNonAlloc(transform.position, transform.forward, _hits);

        if (numHits == 0) return;

        Vector3 displacement = _hits[0].point - transform.position;

        if (rotationMode == RotationMode.Euler)
        {
            float xOffset = wand.localPosition.x;
            float yOffset = wand.localPosition.y;
            float distance = displacement.magnitude - wand.localPosition.z;

            float xCorrection = Mathf.Atan2(yOffset, distance) * Mathf.Rad2Deg;
            float yCorrection = -Mathf.Atan2(xOffset, distance) * Mathf.Rad2Deg;
            Debug.Log(yCorrection);

            wand.localRotation = Quaternion.Euler(xCorrection, yCorrection, 0);
            return;
        }

        wand.rotation = Quaternion.LookRotation(_hits[0].point - wand.position);
    }
}