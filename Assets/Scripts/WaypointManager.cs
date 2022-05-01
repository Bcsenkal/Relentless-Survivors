using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    private Waypoints waypointsScript;
    private void Awake() 
    {
        waypointsScript = GetComponent<Waypoints>();
          
    }
    //Calls GetWaypointPositions method by passed stage number and returns that Vector3 array
    public Vector3[] GetCurrentStagePath(int stage)
    {
        if(stage == 1)
        {
            return GetWaypointPositions(waypointsScript.stageOneWaypoints);
        }
        else
        {
            return null;
        }
    }
    //Creates and returns Vector3 array by passed transform array
    private Vector3[] GetWaypointPositions(Transform[] waypointArray)
    {
        var array = new Vector3[waypointArray.Length]; 
        for(int i = 0; i < waypointArray.Length; i++)
        {
            array[i] = waypointArray[i].transform.position;
        }
        return array;
    }
}
