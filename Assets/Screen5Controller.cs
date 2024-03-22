using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Screen5Controller : MonoBehaviour
{
    public bool _IsPaused = false;
    public bool _IsPlayable = true;
    public bool _IsGameOver = false;
    public bool _IsPWin = false;

    public Slider _sayac, _playerpoints;
    public Button _pause;

    public GameObject _panelPause, _panelP1Win, _panelP2Win, _panelGameOver;
    public Button _PauseButton1, _PauseButton2, _PauseButton3, _P1WinButton1, _P1WinButton2, _P1WinButton3, _P2WinButton1, _P2WinButton2, _P2WinButton3, _restartB1, _restartB2, _restartB3;
    
    private void Awake()
    {
        _panelPause = GameObject.Find("PanelPause");
        _panelP1Win = GameObject.Find("PanelPlayer1Win");
        _panelP2Win = GameObject.Find("PanelPlayer2Win");
        _panelGameOver = GameObject.Find("PanelGameOver");

        _PauseButton1 = GameObject.Find("1ButtonContinue").GetComponent<Button>();
        _PauseButton2 = GameObject.Find("1ButtonMainMenu").GetComponent<Button>();
        _PauseButton3 = GameObject.Find("1ButtonExit").GetComponent<Button>();

        _P1WinButton1 = GameObject.Find("2ButtonRestart").GetComponent<Button>();
        _P1WinButton2 = GameObject.Find("2ButtonMainMenu").GetComponent<Button>();
        _P1WinButton3 = GameObject.Find("2ButtonExit").GetComponent<Button>();

        _P2WinButton1 = GameObject.Find("3ButtonRestart").GetComponent<Button>();
        _P2WinButton2 = GameObject.Find("3ButtonMainMenu").GetComponent<Button>();
        _P2WinButton3 = GameObject.Find("3ButtonExit").GetComponent<Button>();

        _restartB1 = GameObject.Find("4ButtonRestart").GetComponent<Button>();
        _restartB2 = GameObject.Find("4ButtonMainMenu").GetComponent<Button>();
        _restartB3 = GameObject.Find("4ButtonExit").GetComponent<Button>();



    }
    private void Start()
    {
        _sayac = GameObject.Find("SliderSayac").GetComponent<Slider>();
        _playerpoints = GameObject.Find("SliderPlayer").GetComponent<Slider>();
        _pause = GameObject.Find("PauseButton").GetComponent<Button>();

        _PauseButton1.onClick.AddListener(_contunieButton);
        _PauseButton2.onClick.AddListener(_mainMenuButton);
        _PauseButton3.onClick.AddListener(_exitButton);

        _P1WinButton1.onClick.AddListener(_RestartGame);
        _P1WinButton2.onClick.AddListener(_mainMenuButton);
        _P1WinButton3.onClick.AddListener(_exitButton);

        _P2WinButton1.onClick.AddListener(_RestartGame);
        _P2WinButton2.onClick.AddListener(_mainMenuButton);
        _P2WinButton3.onClick.AddListener(_exitButton);

        _restartB1.onClick.AddListener(_RestartGame);
        _restartB2.onClick.AddListener(_mainMenuButton);
        _restartB3.onClick.AddListener(_exitButton);

        _pause.onClick.AddListener(_OpenPausePanel);

        DefaultSettings();
    }

    void DefaultSettings()
    {
        _sayac.maxValue = 60f;
        _playerpoints.maxValue = 100f;

        _sayac.minValue = 0f;
        _playerpoints.minValue = 0f;

        _sayac.value = 60f;
        _playerpoints.value = 50f;

        _panelPause.SetActive(false);
        _panelP1Win.SetActive(false);
        _panelP2Win.SetActive(false);
        _panelGameOver.SetActive(false);
    }
    void _RestartGame()
    {
        SceneManager.LoadScene("Scene5");
    }

    void _OpenPausePanel()
    {
        _panelPause.SetActive(true);
        _IsPaused = true;
    }

    void _contunieButton()
    {
        _panelPause.SetActive(false);
        _IsPaused = false;
    }
    void _mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    void _exitButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (_IsPaused == true || _IsGameOver == true || _IsPWin == true)
        {
            _IsPlayable = false;
        }
        else
        {
            _IsPlayable = true;
        }


        if (_IsPlayable == true)
        {
            Time.timeScale = 1f;
            if (_sayac.value > 0f)
            {
                _sayac.value -= Time.deltaTime;
            }
            else if (_sayac.value == 0f)
            {
                _panelGameOver.SetActive(true);
            }

            if (_playerpoints.value > 0f && _playerpoints.value < 100f)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _playerpoints.value += 5f;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _playerpoints.value -= 5f;
                }
            }
        }
        else 
        {
            Time.timeScale = 0f;
        }

        if (_playerpoints.value == 0f)
        {
            Debug.Log("Player 2 kazandý"); // blue
            _panelP2Win.SetActive(true);
            _IsPWin = true;
        }
        else if (_playerpoints.value == 100f)
        {
            Debug.Log("Player 1 kazandý"); //red
            _panelP1Win.SetActive(true);
            _IsPWin = true;
        }
    }


}
