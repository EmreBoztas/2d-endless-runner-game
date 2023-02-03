using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterControl : MonoBehaviour
{
    private Animation _animation;
    private Rigidbody2D _rb;
    [SerializeField] private float _force = 50;
    private bool _isGrounded = false;
    private bool _jump = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
    
        if(Input.GetMouseButtonDown(0))
        {
            if (_isGrounded)
            {
                _isGrounded = false;     
                _jump = true;
                _animation.Jump(true);      
            }
        }
        else if (_isGrounded == true)
        {
            _animation.Jump(false);
        }
        if(Input.GetMouseButtonDown(1))
        {
            _animation.trip(true);
        }
        if(Input.GetMouseButtonUp(1))
        {   
            _animation.trip(false);
        }
    }
    private void FixedUpdate() {
        jumpAction();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void jumpAction()
    {
        if (_jump)
        {
            _rb.AddForce(new Vector2(0, _force), ForceMode2D.Impulse);
            _jump = false;
        }
    }
}
