using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    Vector3 mousePos;
    public Vector3 offset;
    public Vector3 screenEdge;
    private void OnEnable() 
    {
        offset = new Vector3(Camera.main.pixelWidth / 10,Camera.main.pixelHeight / 10,10);
        screenEdge = new Vector3(Camera.main.pixelWidth,Camera.main.pixelHeight,10) - offset;
        FollowMouse();
        ConstraintTooltipPosition();
    }
    private void Update() 
    {
        FollowMouse();
        ConstraintTooltipPosition();
    }
    private void FollowMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var screenPoint = Camera.main.WorldToScreenPoint(mousePos);
        Debug.Log("ScreenPoint: " + screenPoint);
        if(screenPoint.x > (screenEdge.x - offset.x) && screenPoint.y > (screenEdge.y - offset.y))
        {
            transform.position = screenPoint - offset;
        }
        else
        {
            transform.position = screenPoint + offset;
        }
        
        Debug.Log("Position :" + transform.position);
    }
    private void ConstraintTooltipPosition()
    {
        if(transform.position.x > screenEdge.x)
        {
            transform.position = new Vector3(screenEdge.x,transform.position.y,transform.position.z);
        }

        if(transform.position.y > screenEdge.y)
        {
            transform.position = new Vector3(transform.position.x,screenEdge.y,transform.position.z);
        }
    }
}
