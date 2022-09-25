using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonSliderScene : MonoBehaviour
{
    public Button playButton;

    public void PlayButtonAction()
    {
        playButton.onClick.AddListener(NextScene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
