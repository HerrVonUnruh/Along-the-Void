using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RoterSkill : MonoBehaviour
{
    private EdgeCollider2D REDSkill3;
    private PolygonCollider2D REDSkill;
    private SpriteRenderer REDSkill2;
    private UnityEngine.U2D.SpriteShapeRenderer REDSkill4;




    void Start()
    {
        REDSkill3 = GetComponent<EdgeCollider2D>();
        REDSkill = GetComponent<PolygonCollider2D>();
        REDSkill2 = GetComponent<SpriteRenderer>();
        REDSkill4 = GetComponent<UnityEngine.U2D.SpriteShapeRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (REDSkill != null)
            {
                REDSkill.enabled = true;
            }
            if (REDSkill2 != null)
            {
                REDSkill2.enabled = true;
            }
            if(REDSkill3 != null)
            {
                REDSkill3.enabled = true;   
            }
            if (REDSkill4 != null)
            {
                REDSkill4.enabled = true;
            }



        }

        if (/*Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3) ||*/ Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0)/* || (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2))*/)
        {
            if (REDSkill != null)
            {
                REDSkill.enabled = false;
            }
            if (REDSkill2 != null)
            {
                REDSkill2.enabled = false;
            }
            if (REDSkill3 != null)
            {
                REDSkill3.enabled = false;
            }
            if (REDSkill4 != null)
            {
                REDSkill4.enabled = false;
            }

        }
    }
}