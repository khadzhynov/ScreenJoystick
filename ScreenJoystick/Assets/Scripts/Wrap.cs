using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        bool wrap = false;

        Vector3 viewportPosition = _camera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0)
        {
            viewportPosition.x = 1;
            transform.position = _camera.ViewportToWorldPoint(viewportPosition);
        }
        else
        {
            if (viewportPosition.x > 1)
            {
                viewportPosition.x = 0;
                transform.position = _camera.ViewportToWorldPoint(viewportPosition);
            }    
        }
        
        
        if (viewportPosition.y < 0)
        {
            viewportPosition.y = 1;
            transform.position = _camera.ViewportToWorldPoint(viewportPosition);
        }
        else
        {
            if (viewportPosition.y > 1)
            {
                viewportPosition.y = 0;
                transform.position = _camera.ViewportToWorldPoint(viewportPosition);
            }    
        }
    }
}
