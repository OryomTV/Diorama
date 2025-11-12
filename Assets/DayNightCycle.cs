using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public sealed class DayNightCycle : MonoBehaviour
{
    [SerializeField, Tooltip("In seconds")] private float cycleSpeed;

    private void Update() => transform.Rotate(360 / cycleSpeed * Time.deltaTime * Vector3.right);
}
