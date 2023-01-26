using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public Animator animator;
    public ColorManager colorVFXAnimator;
    public PlayerController speedVFXAnimator;
    public DashScript dashVFXAnimator;
    //public GameManager starVFXAnimator;

    public void Green()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
       {
            animator.SetBool("GreenIsActive", true);
           
        }
        if (colorVFXAnimator.redIsActive)
        {
            animator.SetBool("GreenIsActive", false);
        }
        
    }

    public void Red()
    {
             if (Input.GetKey(KeyCode.Joystick1Button1) && colorVFXAnimator.greenIsActive  /*&& !colorVFXAnimator.redIsActive && !Input.GetKey(KeyCode.Joystick1Button0)*/)
       {
            animator.SetBool("RedIsActive", true);
       }
        if (Input.GetKeyUp(KeyCode.Joystick1Button1)/* || colorVFXAnimator.greenIsActive*/)
        {
            animator.SetBool("RedIsActive", false);
        }
    }

    public void Speed()
    {
        animator.SetFloat("Speed", (speedVFXAnimator.Geschwindigkeit));
    }

    public void Dash()
    {
        if (dashVFXAnimator.isDashing)
        {
            animator.SetTrigger("IsDashing");

        }
    }

    //public void Stars()
    //{
    //    animator.SetBool("StarIsCollected", true);
    //}

    private void Update()
    {
        Speed();
        Green();
        Red();
        Dash();
    }
}
