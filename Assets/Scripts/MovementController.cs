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

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;

    private AnimatedSpriteRenderer _activeSpriteRenderer;
    private Vector2 _direction = Vector2.down;
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _activeSpriteRenderer = spriteRendererDown;
        
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);

        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);

        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, _activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        var position = Rigidbody.position;
        var translation = _direction * (speed * Time.fixedDeltaTime);
        
        Rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        _direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        _activeSpriteRenderer = spriteRenderer;
        _activeSpriteRenderer.idle = _direction == Vector2.zero;
    }
}
