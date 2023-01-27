using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public Animator animator;
    public ColorManager colorVFXAnimator;
    public PlayerController speedVFXAnimator;
    public DashScript dashVFXAnimator;
    public float waitTime = 0.5f;
    public bool hasCoolDownGreen = true;
    public bool hasCoolDownRed;

    //public GameManager starVFXAnimator;



    public void Green()
    {
        if (colorVFXAnimator.greenIsActive)
        {
            hasCoolDownRed = false;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && hasCoolDownGreen == false)
        {
            StartCoroutine("WaitGreen");
        }
    }

    public void Red()
    {
        if (colorVFXAnimator.redIsActive)
        {
            hasCoolDownGreen = false;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && hasCoolDownRed == false)
        {
            StartCoroutine("WaitRed");
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

    public void Gravity()
    {
        animator.SetBool("IsGravityControlVFX", true);
    }

    public IEnumerator WaitGreen()
    {

        animator.SetBool("GreenIsActive", true);
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("GreenIsActive", false);
        hasCoolDownGreen = true;


    }

    public IEnumerator WaitRed()
    {

        animator.SetBool("RedIsActive", true);
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("RedIsActive", false);
        hasCoolDownRed = true;


    }
    private void Update()
    {
        Speed();
        Green();
        Red();
        Dash();
    }
}