using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MTimer : MonoBehaviour
{

    public float timeLeft = 60.0f;
    //counting down
    public Text startText;


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //make hit points go back to zero?
            //Refresh the remaining time so the game restart
            timeLeft = 60.0f;
        }
    }
}