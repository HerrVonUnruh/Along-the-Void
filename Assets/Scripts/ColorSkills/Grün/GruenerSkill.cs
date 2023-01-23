using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class GruenerSkill : MonoBehaviour
{
    public float bounce = 20f;
    private PolygonCollider2D GreenColliderSkill;
    private SpriteRenderer GreenSkill;
    //private UnityEngine.U2D.SpriteShapeRenderer GreenColliderSkill2;
    //private EdgeCollider2D GreenColliderSkill3;
    public Rigidbody2D Player;
    //public PlayerController Jump;


    public ColorManager Green;
    public Sprite greySprite;
    public Sprite greenSprite;
    public Material[] material;
    public bool isGreenShining;

    public Animator animator;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& Green.greenIsActive*/)
        {
            Debug.Log("BOING");
            Player.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            animator.SetBool("PlayerIsJumping", true);
            // isJumping = true;
            //Jump.ShroomCheck();
        }
        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
            collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)
        {

            isGreenShining = true;

        }
        // else
        // {
        //     isJumping = false;
        // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& Green.greenIsActive*/)
        {
            animator.SetBool("PlayerIsJumping", false);
        }
        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
          collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)
        {
            
            isGreenShining = false;
            
        }
    }



    void Start()
    {
        GreenSkill = GetComponent<SpriteRenderer>();
        GreenColliderSkill = GetComponent<PolygonCollider2D>();
        //GreenColliderSkill2 = GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
        //GreenColliderSkill3 = GetComponent<EdgeCollider2D>();
        //GreenColliderSkill4 = GetComponent<TilemapCollider2D>();

    }

    void Update()
    {
        Green.Green();
        Green.Red();
        //Green.Blue();
        //Green.Yellow();



        if (Green.greenIsActive && isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (GreenSkill != null )
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greenSprite;
            }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = true;
            }
            //if (GreenColliderSkill2 != null)
            //{
            //    GreenColliderSkill2.enabled = true;
            //}
            //if (GreenColliderSkill3 != null)
            //{
            //    GreenColliderSkill3.enabled = true;
            //}

            animator.SetBool("GreenIsActivated", true);
        }

        if (Green.greenIsActive && !isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (GreenSkill != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
            }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }

            animator.SetBool("GreenIsActivated", true);
        }



        if (!isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (GreenSkill != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
            }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }
            //if (GreenColliderSkill2 != null)
            //{
            //    GreenColliderSkill2.enabled = false;
            //}
            //if (GreenColliderSkill3 != null)
            //{
            //    GreenColliderSkill3.enabled = false;
            //}
            
            animator.SetBool("GreenIsActivated", false);
        }
        if (!Green.greenIsActive && isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[0];
            
            if (GreenSkill != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
            }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }

            animator.SetBool("GreenIsActivated", true);
        }
    }

    // public void ShroomJump()
    // {
    //     animator.enabled = false;
    // }
}
