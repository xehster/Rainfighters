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
    public int player1Score = 0;
    public int player2Score = 0;

    private void Awake()
    {
        SetupPlayerActions();
    }

    private void SetupPlayerActions()
    {
        player1.OnGetHit += AddScorePlayer2;
        player2.OnGetHit += AddScorePlayer1;
    }

    public void AddScorePlayer1()
    {
        player1Score += 1;
        uiManager.player1ScoreUI.text = player1Score.ToString();
    }
    
    public void AddScorePlayer2()
    {
        player2Score += 1;
        uiManager.player2ScoreUI.text = player2Score.ToString();
    }
    
}
