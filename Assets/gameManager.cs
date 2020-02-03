using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ML;

public class gameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;


    private void Start()
    {
        
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);/*
        if (birdID == birdPopulation.players.Count)
        {
            mutateBirdPopulation();
            Info4.info4 = (int)(birdPopulation.players[0].gene[0, 0] * 100);
            birdID = 0;
        }
        Info3.info3 = birdID;
        Info2.info2 = birdPopulation.players.Count;
        flyLittleBird.Theta = birdPopulation.players[birdID].gene;
        */

    }
    
    public void GameOver()
    {

        //Info3.info3 = birdScore;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;

        

    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
