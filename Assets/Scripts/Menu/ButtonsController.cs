using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    public Button newGameButton;

    public Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        Button newgamebtn = newGameButton.GetComponent<Button>();
        newgamebtn.onClick.AddListener(NewGame);

        Button continuebtn = continueButton.GetComponent<Button>();
        continuebtn.onClick.AddListener(ContinueGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SliderScene");
    }
    
    public void ContinueGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
