using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator _anim;

    private void Awake() {
        _anim = GetComponent<Animator>();
    }
    public void Jump(bool isJump)
    {
        _anim.SetBool("isJump", isJump);
    }
    public void Die()
    {
        _anim.SetTrigger("die");
    }
    public void trip(bool isTrip)
    {
        _anim.SetBool("isTrip", isTrip);
    }
}
