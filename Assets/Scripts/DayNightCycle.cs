using System;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;

using UnityEngine;


public sealed class DayNightCycle : MonoBehaviour
{
    [SerializeField, Tooltip("In seconds")] private float cycleDuration;
    private void Update() => transform.Rotate(360 / cycleDuration * Time.deltaTime * Vector3.right);

    [Conditional("UNITY_EDITOR"), ContextMenu(nameof(Skip90Degrees))]
    private void Skip90Degrees() => transform.Rotate(90 * Vector3.right);
}
