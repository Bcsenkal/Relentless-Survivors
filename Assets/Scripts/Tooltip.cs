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
        mousePos = Input.mousePosition;
        if(mousePos.x > (screenEdge.x - offset.x) && mousePos.y > (screenEdge.y - offset.y))
        {
            transform.position = mousePos - offset;
        }
        else
        {
            transform.position = mousePos + offset;
        }
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
