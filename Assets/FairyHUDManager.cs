using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyHUDManager : MonoBehaviour
{
    public GameObject player;
    public float offset_x;
    public float offset_y;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        if (player.transform.localScale.y > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset_x, playerPosition.y - offset_y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}