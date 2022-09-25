using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    public TMP_Text winnerText;

    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Player1Score") > PlayerPrefs.GetInt("Player2Score"))
        {
            winnerText.text = "Congratz, Player 1, you won";
        }
        else if (PlayerPrefs.GetInt("Player2Score") > PlayerPrefs.GetInt("Player1Score"))
        {
            winnerText.text = "Congratz, Player 2, you won";
        }
        else if (PlayerPrefs.GetInt("Player1Score") == PlayerPrefs.GetInt("Player2Score"))
        {
            winnerText.text = "Congratz, both players, you won";
        }
    }

    public void ExitButtonAction()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
// Update is called once per frame
    void Update()
    {
        
    }
}
