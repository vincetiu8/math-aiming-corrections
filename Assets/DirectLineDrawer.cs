using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectLineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    private RaycastHit[] _hits;

    private void Awake()
    {
        _hits = new RaycastHit[1];
    }

    private void FixedUpdate()
    {
        int numHits = Physics.RaycastNonAlloc(transform.position, transform.forward, _hits);

        crosshair.SetActive(numHits != 0);
        
        if (numHits == 0) return;

        crosshair.transform.position = _hits[0].point;
    }
}
