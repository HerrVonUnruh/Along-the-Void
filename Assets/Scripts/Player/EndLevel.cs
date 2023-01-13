using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    public Timer timer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && timer.timeValue < 600f)
        {
            SceneManager.LoadScene("EndScreen");
        }

        if (collision.transform.CompareTag("Player") && timer.timeValue >= 600f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }




}
