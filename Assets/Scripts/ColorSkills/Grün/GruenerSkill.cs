using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class GruenerSkill : MonoBehaviour
{
    private PolygonCollider2D GreenColliderSkill;
    public float bounce = 20f;
    // private SpriteRenderer GreenSkill;
    private UnityEngine.U2D.SpriteShapeRenderer GreenColliderSkill2;
    private EdgeCollider2D GreenColliderSkill3;
    public PlayerController Jump;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            animator.SetBool("PlayerIsJumping", true);
            // isJumping = true;
            //Jump.ShroomCheck();
        }
        // else
        // {
        //     isJumping = false;
        // }
    }


    void Start()
    {
    //    GreenSkill = GetComponent<SpriteRenderer>();
        GreenColliderSkill = GetComponent<PolygonCollider2D>();
        GreenColliderSkill2 = GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
        GreenColliderSkill3 = GetComponent<EdgeCollider2D>();
        //GreenColliderSkill4 = GetComponent<TilemapCollider2D>();

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
        //    if (GreenSkill != null)
        //    {
        //        GreenSkill.enabled = true;
        //    }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = true;
            }
            if (GreenColliderSkill2 != null)
            {
                GreenColliderSkill2.enabled = true;
            }
            if (GreenColliderSkill3 != null)
            {
                GreenColliderSkill3.enabled = true;
            }

            animator.SetBool("GreenIsActivated", true);
        }

            if (/*Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3) ||*/ Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1)/* || (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2))*/ )
            
        {
            // if (GreenSkill != null)
            // {
            //     GreenSkill.enabled = false;
            // }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = false;
            }
            if (GreenColliderSkill2 != null)
            {
                GreenColliderSkill2.enabled = false;
            }
            if (GreenColliderSkill3 != null)
            {
                GreenColliderSkill3.enabled = false;
            }
            
            animator.SetBool("GreenIsActivated", false);
        }
    }

    // public void ShroomJump()
    // {
    //     animator.enabled = false;
    // }
}
