using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterControl : MonoBehaviour
{
    Animation _animation;
    Rigidbody2D _rb;

    Vector2 startTouchPosition; 
    float minSwipeDistance = 50f; 
    bool _isTripping = false;

    [SerializeField] float _force = 50;
    bool _isGrounded = false;
    bool _jump = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _animation.trip(true);
            _isTripping = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) 
        {   
            _animation.trip(false);
            _isTripping = false;
        }

        // Swipe Control

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 currentTouchPosition = touch.position;
                    float swipeDeltaY = currentTouchPosition.y - startTouchPosition.y;

                    if (swipeDeltaY < -minSwipeDistance && !_isTripping)
                    {
                        _animation.trip(true);
                        _isTripping = true;
                    }
                    break;

                case TouchPhase.Ended:
                    
                    if (_isTripping)
                    {
                        _animation.trip(false);
                        _isTripping = false;
                    }
                    else 
                    {
                        Vector2 endTouchPosition = touch.position;
                        float deltaX = endTouchPosition.x - startTouchPosition.x;
                        float deltaY = endTouchPosition.y - startTouchPosition.y;

                        if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX) && deltaY > minSwipeDistance)
                        {
                            if (_isGrounded)
                            {
                                _isGrounded = false;     
                                _jump = true;
                                _animation.Jump(true);      
                            }
                        }
                    }
                    break; 
            }
        }
        else if (_isGrounded == true && !_isTripping) 
        {
             _animation.Jump(false);
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
