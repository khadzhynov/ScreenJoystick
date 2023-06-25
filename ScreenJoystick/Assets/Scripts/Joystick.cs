using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _container;
    [SerializeField] private RectTransform _spot;
    [SerializeField] private float _radius = 100f;

    [SerializeField] private bool _centerOnRelease = true;
    [SerializeField] private bool _dynamic = false;

    public UnityEvent<Vector2> OnValueChanged;
    
    public Vector2 Value { get; private set; }


    private void Update()
    {
        if (_dynamic)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _container.position = _canvas.WorldPosition(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                UpdateJoystick(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Release();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_dynamic)
        {
            UpdateJoystick(eventData.position);
        }
    }

    private void UpdateJoystick(Vector2 position)
    {
        var containerScreenPosition = _canvas.ScreenPosition(_container);

        Vector2 offset = position - containerScreenPosition;

        offset = offset.normalized * Mathf.Clamp(offset.magnitude, 0, _radius);

        Vector2 spotScreenPosition = containerScreenPosition + offset;

        Vector3 spotPosition = _canvas.WorldPosition(spotScreenPosition);

        _spot.position = spotPosition;

        UpdateValue(offset);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Release();
    }

    private void Release()
    {
        if (_centerOnRelease)
        {
            _spot.position = _container.position;
            UpdateValue(Vector2.zero);
        }
    }

    private void UpdateValue(Vector2 screenSpaceOffset)
    {
        Value = new Vector2(screenSpaceOffset.x / _radius, screenSpaceOffset.y / _radius);
        
        OnValueChanged?.Invoke(Value);
            
        Debug.Log("Value " + Value);
    }
}
