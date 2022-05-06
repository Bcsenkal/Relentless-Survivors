using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private Waypoints[] waypointsObjectArray;
    [SerializeField] public Vector3[] currentPath{get; private set;}
    public static WaypointManager instance;
    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentPath(int level)
    {
        currentPath = GetWaypointPositions(waypointsObjectArray[level-1].waypoints);
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
