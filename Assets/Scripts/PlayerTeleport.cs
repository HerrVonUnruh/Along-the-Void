using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    private GameObject teleporter;
    private GameObject player;
    public ColorManager colorManager;
    public bool canTeleport = false;
    public float teleportCoolDown = 10f;





    private void Start()
    {
        player = GameObject.FindWithTag("TeleportCollider");
    }
    void Update()
    {
        //if (colorManager.yellowIsActive && teleportCoolDown == 0f)
        //{
        //    canTeleport = true;
        //}

        //if(teleportCoolDown > 0f)
        //{
        //    canTeleport = false;
        //    if (canTeleport == false && teleportCoolDown > 0f)
        //    {
        //        teleportCoolDown = teleportCoolDown - 1f * Time.deltaTime;
        //        if(teleportCoolDown < 0f)
        //        {
        //            teleportCoolDown = 0f;
        //        }
        //    }
        //}

        //if (colorManager.yellowIsActive && canTeleport == true)
        //{
        //    if(teleporter != null)
        //    {
        //        transform.position = teleporter.GetComponent<Teleporter>().GetDestination().position;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(teleporter.transform.position.x, transform.position.y);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Teleporter"))
    //    {
    //        currentTeleporter = collision.gameObject;

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Teleporter"))
    //    {
    //        if (collision.gameObject == currentTeleporter)
    //        {

    //            teleportCoolDown = 5f;
    //            currentTeleporter = null;
    //        }
    //    }
    //}
}
