using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Waypoints")]
public class Waypoints : ScriptableObject
{
    [SerializeField] public Transform[] waypoints;
}
