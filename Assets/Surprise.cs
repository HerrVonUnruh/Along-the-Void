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
    public GameObject[] cameraList;
    private int currentCamera;
    public PlayerController playerController;


    void Start()
    {
        Fairy = GetComponent<Rigidbody2D>();
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
        }

        if (cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }

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
            currentCamera++;
            if (currentCamera < cameraList.Length)
            {
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);
            }

        }

        MovementController();
        FarCam();

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
                if (Input.GetAxis("Left Trigger") > 0f && canMove)
                {
                    currentCamera = 3;
                    cameraList[currentCamera - 3].gameObject.SetActive(false);
                    cameraList[currentCamera - 2].gameObject.SetActive(false);
                    cameraList[currentCamera - 1].gameObject.SetActive(false);
                    cameraList[currentCamera + 1].gameObject.SetActive(false);
                    cameraList[currentCamera + 2].gameObject.SetActive(false);
                    cameraList[currentCamera].gameObject.SetActive(true);
                }
            }
            if ((Input.GetAxis("Left Trigger") < 1f && canMove))
            {
                currentCamera = 0;
                cameraList[currentCamera + 1].gameObject.SetActive(false);
                cameraList[currentCamera + 2].gameObject.SetActive(false);
                cameraList[currentCamera + 3].gameObject.SetActive(false);
                cameraList[currentCamera + 4].gameObject.SetActive(false);
                cameraList[currentCamera + 5].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);
            }
        }


        void MovementController()
        {
            if (playerController.Geschwindigkeit > 20f && !canMove && playerController.Direction > 0f)
            {

                currentCamera = 2;
                cameraList[currentCamera + 3].gameObject.SetActive(false);
                cameraList[currentCamera + 2].gameObject.SetActive(false);
                cameraList[currentCamera + 1].gameObject.SetActive(false);
                cameraList[currentCamera - 2].gameObject.SetActive(false);
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);

            }
            if (playerController.Geschwindigkeit > 20f && !canMove && playerController.Direction < 0f)
            {
                currentCamera = 5;
                cameraList[currentCamera - 5].gameObject.SetActive(false);
                cameraList[currentCamera - 4].gameObject.SetActive(false);
                cameraList[currentCamera - 3].gameObject.SetActive(false);
                cameraList[currentCamera - 2].gameObject.SetActive(false);
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);
            }

                if (playerController.Geschwindigkeit < 20f && !canMove)
                {
                    currentCamera = 1;
                    cameraList[currentCamera + 4].gameObject.SetActive(false);
                    cameraList[currentCamera + 3].gameObject.SetActive(false);
                    cameraList[currentCamera + 2].gameObject.SetActive(false);
                    cameraList[currentCamera + 1].gameObject.SetActive(false);
                    cameraList[currentCamera - 1].gameObject.SetActive(false);
                    cameraList[currentCamera].gameObject.SetActive(true);


                }

            }
            void FarCam()
            {
                if (Input.GetAxis("Left Trigger") > 0f && !canMove)
                {
                    currentCamera = 4;
                    cameraList[currentCamera - 4].gameObject.SetActive(false);
                    cameraList[currentCamera - 3].gameObject.SetActive(false);
                    cameraList[currentCamera - 2].gameObject.SetActive(false);
                    cameraList[currentCamera - 1].gameObject.SetActive(false);
                    cameraList[currentCamera + 1].gameObject.SetActive(false);
                    cameraList[currentCamera].gameObject.SetActive(true);
                }
            }
        }

    }


