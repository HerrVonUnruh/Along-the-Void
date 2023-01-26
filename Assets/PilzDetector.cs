using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PilzDetector : MonoBehaviour
{
    public ColorManager Green;
    public bool isGreenShining;
    [SerializeField] PauseMenue pauseMenue;


    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "ColorDetector" && !Green.greenIsActive && Green.redIsActive ||
            collision.gameObject.tag == "ColorDetector" && Green.greenIsActive && !Green.redIsActive)
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
    }
}
