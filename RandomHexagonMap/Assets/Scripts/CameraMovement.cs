using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float cameraScroll;
    private float xPosition, yPosition, zPosition;
    
    void Start()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;
        cameraScroll = 0f;
    }


    void Update()
    {
        float currentScrollMovement = Input.GetAxis("Mouse ScrollWheel");

        if (currentScrollMovement != 0f)
        {
            cameraScroll = Mathf.Clamp(cameraScroll + currentScrollMovement*-1, -2f, 2f);
            yPosition = (12 + cameraScroll * 2);
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && zPosition > 3)
        {
            zPosition -= 0.2f;

        } else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && zPosition < 86)
        {
            zPosition += 0.2f;
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && xPosition>10)
        {
            xPosition -= 0.2f;

        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && xPosition<92)
        {
            xPosition += 0.2f;
        }

        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }
}
