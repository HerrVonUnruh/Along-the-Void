using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RoterSkill : MonoBehaviour
{
    private PolygonCollider2D REDSkill;
    private SpriteRenderer REDSkill2;
    //private EdgeCollider2D REDSkill3;
    //private UnityEngine.U2D.SpriteShapeRenderer REDSkill4;

    public Sprite greySprite;
    public Sprite redSprite;
    public bool isRedShining;
    public ColorManager Red;
    public Material[] material;
    


    void Start()
    {
        REDSkill = GetComponent<PolygonCollider2D>();
        REDSkill2 = GetComponent<SpriteRenderer>();
        //REDSkill3 = GetComponent<EdgeCollider2D>();
        //REDSkill4 = GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Red.Green();
        //Red.Blue();
        //Red.Yellow();
        Red.Red();





        if (Red.redIsActive && isRedShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (REDSkill != null)
            {
                REDSkill.enabled = true;
            }
            if (REDSkill2 != null)
            {
               this.gameObject.GetComponent<SpriteRenderer>().sprite = redSprite;
            }
            //if(REDSkill3 != null)
            //{
            //    REDSkill3.enabled = true;   
            //}
            //if (REDSkill4 != null)
            //{
            //    REDSkill4.enabled = true;
            //}



        }

        if (Red.redIsActive && !isRedShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            if (REDSkill != null)
            {
                REDSkill.enabled = true;
            }
            if (REDSkill2 != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
            }


        }
            if (!isRedShining)
        {
            if (REDSkill2 != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
                this.gameObject.GetComponent<SpriteRenderer>().material = material[1];
            }
        }
        if (!Red.redIsActive && isRedShining)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = material[0];
            this.gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;
            if (REDSkill != null)
            {
                REDSkill.enabled = false;
            }
           
            //if (REDSkill3 != null)
            //{
            //    REDSkill3.enabled = false;
            //}
            //if (REDSkill4 != null)
            //{
            //    REDSkill4.enabled = false;
            //}
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ColorDetector" && !Red.redIsActive || 
            collision.gameObject.tag == "ColorDetector" && Red.redIsActive)
        {
            
            isRedShining = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ColorDetector" && !Red.redIsActive || 
            collision.gameObject.tag == "ColorDetector" && Red.redIsActive)
        {
          
            isRedShining = false;
            
        }
    }
}