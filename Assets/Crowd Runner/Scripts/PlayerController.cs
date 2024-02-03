using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float moveSpeed = 1f;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed = 4f;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;    

    void Start()
    {
        
    }

    void Update()
    {
        MoveForward();
        ManageControl();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xAxisScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xAxisScreenDifference /= Screen.width;
            xAxisScreenDifference *= slideSpeed;
            
            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xAxisScreenDifference;
            transform.position = position;

        }
    }
}
