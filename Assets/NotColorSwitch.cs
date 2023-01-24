using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotColorSwitch : MonoBehaviour
{
    public bool isTriggerd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isTriggerd = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTriggerd = true;
        }
    }
}
