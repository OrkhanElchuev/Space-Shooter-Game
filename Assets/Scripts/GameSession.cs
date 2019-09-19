using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int score = 0;

    private void Awake()
    {
        SetUpSingleton();    
    }

    private void SetUpSingleton()
    {
        // If there are more than one GameSession objects destroy 
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    // Add to score value
    public void AddToScore(int score)
    {
        this.score += score;
    }

    // Destroy GameSession object
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
