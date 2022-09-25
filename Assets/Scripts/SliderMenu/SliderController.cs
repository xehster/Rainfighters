using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;
    private int defaultSliderValue = 1;
    public void OnSliderChanged(float value)
    {
        valueText.text = value.ToString() + " rounds"; 
        PlayerPrefs.SetFloat("howManyRoundsToPlay", value);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        OnSliderChanged(defaultSliderValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
