using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    public void Jump(bool isJump)
    {
        anim.SetBool("isJump", isJump);
    }
    public void Die()
    {
        anim.SetTrigger("die");
    }
    public void trip(bool isTrip)
    {
        anim.SetBool("isTrip", isTrip);
    }
}
