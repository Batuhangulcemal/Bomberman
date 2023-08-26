using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }

    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    
    private Vector2 _direction = Vector2.down;
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down);

        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left);

        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right);
        }
        else
        {
            SetDirection(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
        var position = Rigidbody.position;
        var translation = _direction * (speed * Time.fixedDeltaTime);
        
        Rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }
}
