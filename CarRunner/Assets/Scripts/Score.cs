using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float timeStep = 0.1f;
    private int FinalScore = 0;
    public Text score;
    public Text GameOver;
    public Text restart;
    private bool SpeedActivated = false;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SpeedActivated == true)
        {
            timeStep += Time.deltaTime * 2;
            FinalScore = (int)timeStep;
            Debug.Log("FinalScore1" + FinalScore);
        }
        else
        {
            timeStep += Time.deltaTime;
            FinalScore = (int)timeStep;
            Debug.Log("FinalScore2" + FinalScore);
        }
        score.text = "Score: " + FinalScore.ToString();
        
        if(gameOver == true)
        {
            GameOver.enabled = true;
            restart.enabled = true;
            Time.timeScale = 0f;    
        }

    }

    public void ActivateScoreSpeed()
    {
        SpeedActivated = true;
    }

    public void DeactivateScoreSpeed()
    {
        SpeedActivated = false;
    }

    public void SetGameOver()
    {
        gameOver = true;
    }
    public void SetGameOverfalse()
    {
        gameOver = false;
        GameOver.enabled = false;
        restart.enabled = false;
        Time.timeScale = 1f;
    }
}
