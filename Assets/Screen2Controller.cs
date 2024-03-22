using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screen2Controller : MonoBehaviour
{
    public Slider _loadingSlider;
    
    private void Start()
    {
        _loadingSlider = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        
        _loadingSlider.value = 15f;
        _loadingSlider.maxValue = 15f;
        _loadingSlider.minValue = 0f;
        
    }
    private void Update()
    {
        _loadingSlider.value -= Time.deltaTime;

        if(_loadingSlider.value<=0f)
        {
            SceneManager.LoadScene("Scene3");
        }

    }
}
