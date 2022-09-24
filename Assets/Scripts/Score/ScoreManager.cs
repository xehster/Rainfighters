using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private Player2Controller player2;
    [SerializeField] private ScoreUIManager uiManager;
    public int player1Score;
    public int player2Score; 

    private void Awake()
    {
        SetupPlayerActions();
    }

    private void Start()
    {
        player1Score = PlayerPrefs.GetInt("Player1Score");
        uiManager.player1ScoreUI.text = player1Score.ToString();
        player2Score = PlayerPrefs.GetInt("Player2Score");
        uiManager.player2ScoreUI.text = player2Score.ToString();
    }

    private void SetupPlayerActions()
    {
        player1.OnGetHit += AddScorePlayer2;
        player2.OnGetHit += AddScorePlayer1;
    }

    public void AddScorePlayer1()
    {
        player1Score += 1;
        PlayerPrefs.SetInt("Player1Score", player1Score);
        Debug.Log("player1 saved score " + PlayerPrefs.GetInt("Player1Score"));
        uiManager.player1ScoreUI.text = player1Score.ToString();
    }
    
    public void AddScorePlayer2()
    {
        player2Score += 1;
        PlayerPrefs.SetInt("Player2Score", player2Score);
        Debug.Log("player2 saved score " + PlayerPrefs.GetInt("Player2Score"));
        uiManager.player2ScoreUI.text = player2Score.ToString();
    }
    
}
