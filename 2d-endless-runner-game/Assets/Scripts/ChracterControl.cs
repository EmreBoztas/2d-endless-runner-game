using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterControl : MonoBehaviour
{
    [SerializeField] private Animation Animation;
    private bool isGround;
    void Start()
    {
        
    }

    void Update()
    {
    
        if(Input.GetMouseButtonDown(0))
        {
            Animation.Jump(true);
        }
        else if (isGround == true)
        {
            Animation.Jump(false);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Animation.trip(true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Animation.trip(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        isGround = false;
    }
}
