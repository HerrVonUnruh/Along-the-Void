using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GruenerSkill : MonoBehaviour
{

    private PolygonCollider2D GreenColliderSkill;
    private CapsuleCollider2D GreenCapsuleColliderSkill;
    private SpriteRenderer GreenSkill;
    public Rigidbody2D Player;
    public ColorManager Green;
    public Sprite greySprite;
    public Sprite greenSprite;
    public Material[] material;
    public bool isGreenShining;
    [SerializeField] PauseMenue pauseMenue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NotColorSwitch"))
        {
            isGreenShining = false;
        }

        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
            collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)
        {

            isGreenShining = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive ||
          collision.gameObject.tag == "ColorDetector" && Green.greenIsActive)
        {

            isGreenShining = false;

        }
    }



    void Start()
    {
        pauseMenue = GameObject.FindObjectOfType<PauseMenue>();
        GreenSkill = GetComponent<SpriteRenderer>();
        GreenColliderSkill = GetComponent<PolygonCollider2D>();
        GreenCapsuleColliderSkill = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {

        if (pauseMenue.GameIsPaused)
        {
            return;
        }
        Green.Green();
        Green.Red();
        //Green.Blue();
        //Green.Yellow();



        if (Green.greenIsActive && isGreenShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (GreenSkill != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greenSprite;
            }
            if (GreenColliderSkill != null)
            {
                GreenColliderSkill.enabled = true;
            }
            if (GreenCapsuleColliderSkill != null)
            {
                GreenCapsuleColliderSkill.enabled = true;
            }
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
            if (GreenCapsuleColliderSkill != null)
            {
                GreenCapsuleColliderSkill.enabled = false;
            }
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
            if (GreenCapsuleColliderSkill != null)
            {
                GreenCapsuleColliderSkill.enabled = false;
            }
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
            if (GreenCapsuleColliderSkill != null)
            {
                GreenCapsuleColliderSkill.enabled = false;
            }
        }
    }
}