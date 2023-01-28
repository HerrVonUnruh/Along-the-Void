using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour
{
    public float Direction = 0f;
    public float DirectionVertical = 0f;
    public float RightTrigger = 0f;
    public float RightStickButton = 0f;
    [SerializeField] public Rigidbody2D Fairy;
    public float Geschwindigkeit = 120f;
    public FairyHUDManager yellowFairyHUDManager;
    public FairyHUDManager blueFairyHUDManager;
    public FairyHUDManager redFairyHUDManager;
    public FairyHUDManager greenFairyHUDManager;
    public bool canMove = false;


    void Start()
    {
        Fairy = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        //Flip();
        Direction = Input.GetAxis("Fairy Horizontal");
        DirectionVertical = Input.GetAxis("Fairy Vertical");
        RightTrigger = Input.GetAxis("Right Trigger");
        //RightStickButton = Input.GetAxis("Right Stick Button");

        if (Input.GetAxis("Right Trigger") > 0f)
        {
            yellowFairyHUDManager.enabled = true;
            blueFairyHUDManager.enabled = true;
            redFairyHUDManager.enabled = true;
            greenFairyHUDManager.enabled = true;
            canMove = false;
            
        }
        Movement();
        //    if (Direction > 0f)
        //    {
        //        yellowFairyHUDManager.enabled = false;
        //        blueFairyHUDManager.enabled = false;
        //        redFairyHUDManager.enabled = false;
        //        greenFairyHUDManager.enabled = false;
        //        Fairy.velocity = new Vector2(Direction * Geschwindigkeit, Fairy.velocity.y);
        //    }


        //    if (Direction < 0f)
        //    {
        //        yellowFairyHUDManager.enabled = false;
        //        blueFairyHUDManager.enabled = false;
        //        redFairyHUDManager.enabled = false;
        //        greenFairyHUDManager.enabled = false;
        //        Fairy.velocity = new Vector2(Direction * Geschwindigkeit, Fairy.velocity.y);

        //    }
        //    if (DirectionVertical > 0f)
        //    {
        //        yellowFairyHUDManager.enabled = false;
        //        blueFairyHUDManager.enabled = false;
        //        redFairyHUDManager.enabled = false;
        //        greenFairyHUDManager.enabled = false;
        //        Fairy.velocity = new Vector2(Fairy.velocity.x, -DirectionVertical * Geschwindigkeit);
        //    }


        //    if (DirectionVertical < 0f)
        //    {
        //        yellowFairyHUDManager.enabled = false;
        //        blueFairyHUDManager.enabled = false;
        //        redFairyHUDManager.enabled = false;
        //        greenFairyHUDManager.enabled = false;
        //        Fairy.velocity = new Vector2(Fairy.velocity.x, -DirectionVertical * Geschwindigkeit);

        //    }
        //}

        void Movement()
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                yellowFairyHUDManager.enabled = false;
                blueFairyHUDManager.enabled = false;
                redFairyHUDManager.enabled = false;
                greenFairyHUDManager.enabled = false;
                canMove = true;
            }
            if (canMove == true)
            {
            if (Direction > 0f)
            {
                Fairy.velocity = new Vector2(Direction * Geschwindigkeit, Fairy.velocity.y);
            }


            if (Direction < 0f)
            {
                //yellowFairyHUDManager.enabled = false;
                //blueFairyHUDManager.enabled = false;
                //redFairyHUDManager.enabled = false;
                //greenFairyHUDManager.enabled = false;
                Fairy.velocity = new Vector2(Direction * Geschwindigkeit, Fairy.velocity.y);

            }
            if (DirectionVertical > 0f)
            {
                //yellowFairyHUDManager.enabled = false;
                //blueFairyHUDManager.enabled = false;
                //redFairyHUDManager.enabled = false;
                //greenFairyHUDManager.enabled = false;
                Fairy.velocity = new Vector2(Fairy.velocity.x, -DirectionVertical * Geschwindigkeit);
            }


            if (DirectionVertical < 0f)
            {
                //yellowFairyHUDManager.enabled = false;
                //blueFairyHUDManager.enabled = false;
                //redFairyHUDManager.enabled = false;
                //greenFairyHUDManager.enabled = false;
                Fairy.velocity = new Vector2(Fairy.velocity.x, -DirectionVertical * Geschwindigkeit);

            }
        }
        }

    }

}

