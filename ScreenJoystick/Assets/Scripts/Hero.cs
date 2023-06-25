using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _movementInput;

    public void UpdateMovement(Vector2 input)
    {
        _movementInput = input;
    }
    
    private void Update()
    {
        transform.position += new Vector3(_movementInput.x, _movementInput.y, 0) * _speed * Time.deltaTime;
    }
}
