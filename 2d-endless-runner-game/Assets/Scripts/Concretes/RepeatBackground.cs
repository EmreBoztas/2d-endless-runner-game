using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    public Rigidbody2D _rb;
    private float _width;
    public float _speed = -3f;
    private float _lastSpeed = -3f;
    
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();

        _width = _boxCollider.size.x;
        _rb.velocity = new Vector2(_speed, 0);
    }

    void Update()
    {
        if(transform.position.x < -_width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {        
        Vector3 vector = new Vector3(_width *2f, 0, 0);
        transform.position = (Vector3)transform.position + vector;
    }

    public void StopMove()
    {
        _rb.velocity = new Vector2(0, 0);
    }
    public void ChangeSpeed(float _score)
    {
        if (_speed > -12)
        {
            _speed = _lastSpeed - _score / 75;
            _rb.velocity = new Vector2(_speed, 0);
        }
    }
}
