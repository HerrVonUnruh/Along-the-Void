using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GruenerPilz : MonoBehaviour
{
    public float bounce = 20f;
    private PolygonCollider2D GreenColliderSkill;
    private SpriteRenderer GreenSkill;
    public Rigidbody2D Player;
    public ColorManager Green;
    public Material[] material;
    public bool isGreenShining;

    public Animator animator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
            collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)
        {

            isGreenShining = true;

        }
        if (collision.gameObject.CompareTag("Player") /*&& Green.greenIsActive*/)
        {
            Debug.Log("BOING");
            Player.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            animator.SetBool("PlayerIsJumping", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
          collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)

        {
            isGreenShining = false;
        }
        if (collision.gameObject.CompareTag("Player") /*&& Green.greenIsActive*/)
        {
            SoundManager.sndMan.PlaySprungSound();
            animator.SetBool("PlayerIsJumping", false);
        }
    }



    void Start()
    {
        GreenSkill = GetComponent<SpriteRenderer>();
        GreenColliderSkill = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Green.Green();
        Green.Red();
        //Green.Blue();
        //Green.Yellow();



        if (Green.greenIsActive && isGreenShining)
        {
            animator.SetBool("GreenIsActivated", true);
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
           

            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = true;
            }
        }

        if (Green.greenIsActive && !isGreenShining)
        {
            animator.SetBool("GreenIsActivated", true);
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
  
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }

        }



        if (!isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (GreenSkill != null)

            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }

            animator.SetBool("GreenIsActivated", false);
        }
        if (!Green.greenIsActive && isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[0];

            animator.SetBool("GreenIsActivated", true);

            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }

        }
    }
}
