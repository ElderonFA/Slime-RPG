using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StopWalkTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        WalkController.onWalkEnd?.Invoke();
        Destroy(gameObject);
    }
}
