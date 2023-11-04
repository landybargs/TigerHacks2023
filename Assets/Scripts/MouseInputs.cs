using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputsScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Left Click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0  - Left Click");

            //Gets the Mouse Position
            //(0,0) at the bottom left
            //(width, height) at the top right
            Debug.Log(Input.mousePosition);

            //ScreenToWorldPoint to get the World Coordinates
            //Can be used for things like spawn GameObject on cursor
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            Debug.Log("Viewport Point: " + Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }

        //Right Click
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 1  - Right Click");
        }

        //Middle Mouse
        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse 2  - Middle Mouse");
        }
    }
}
