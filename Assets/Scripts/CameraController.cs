using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float startTime, endTime;
    private bool isBeingPressed;
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
        endTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isBeingPressed)
                return; 
            if(startTime > 0.5f)
            {
                //Debug.Log("pressed");
                isBeingPressed = true;
            }
            startTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            startTime = 0f;
            isBeingPressed = false;
        }
        //if (Input.GetMouseButtonDown(0))
        //    startTime = Time.time;
        //if (Input.GetMouseButtonUp(0))
        //    endTime = Time.time;
        //if (endTime - startTime >= 1f)
        //{
        //    Debug.Log("1");
        //    startTime = 0f;
        //    endTime = 0f;   
        //}
    }
}
