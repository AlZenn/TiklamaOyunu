using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Screen1Controller : MonoBehaviour
{
  
    public string _stringad, _stringkarakterad, _stringkarakternick;

    //public Text deneme1;
    //public Scene1Data _Scene1Data;
    public Button _Start, _HowToPlay, _Credits, _CloseTutorial, _CloseCredits;
    public GameObject _PanelStart, _PanelTutorial, _PanelCredits;
    public InputField _inputName, _inputPName, _inputPNickname;
    public GameObject _Button1, _Button2, _input1,_input2,_input3;
    private void Awake()
    {
        

        _Button1 = GameObject.Find("CloseCredits");
        _Button2 = GameObject.Find("CloseTutorial");
        
        _input1 = GameObject.Find("InputName");
        _input2 = GameObject.Find("InputPlayerName");
        _input3 = GameObject.Find("InputPlayerNickname");
        
        _PanelStart = GameObject.Find("PanelStart");
        _PanelTutorial = GameObject.Find("PanelTutorial");
        _PanelCredits = GameObject.Find("PanelCredits");
        
        _inputName =GameObject.Find("InputName").GetComponent<InputField>();
        _inputPName =GameObject.Find("InputPlayerName").GetComponent<InputField>();
        _inputPNickname =GameObject.Find("InputPlayerNickname").GetComponent<InputField>();
        
        _CloseCredits = GameObject.Find("CloseCredits").GetComponent<Button>();
        _CloseTutorial = GameObject.Find("CloseTutorial").GetComponent<Button>();
        
    }

    private void Start()
    {
        //_Scene1Data = GameObject.Find("veriAktarimi").GetComponent<Scene1Data>();

            _PanelStart.SetActive(false);
            _PanelTutorial.SetActive(false);
            _PanelCredits.SetActive(false);
            
            
            
            _input1.SetActive(false);
            _input2.SetActive(false);
            _input3.SetActive(false);

            _Start = GameObject.Find("Start").GetComponent<Button>();
            _HowToPlay = GameObject.Find("HowToPlay").GetComponent<Button>();
            _Credits = GameObject.Find("Credits").GetComponent<Button>();
            
            _Button1.SetActive(false);
            _Button2.SetActive(false);
            

            _Start.onClick.AddListener(_StartButtonClicked);
            _HowToPlay.onClick.AddListener(_HowToPlayButtonClicked);
            _Credits.onClick.AddListener(_CreditsButtonClicked);
            _CloseCredits.onClick.AddListener(_PanelCreditsOff);
            _CloseTutorial.onClick.AddListener(_PanelTutorialOff);

    }

    public void _PanelCreditsOff()
    {
        _PanelCredits.SetActive(false);
        
        
    }
    public void _PanelTutorialOff()
    {
        
        _PanelTutorial.SetActive(false);
        
    }

    public void _StartButtonClicked()
    {
        _PanelStart.SetActive(true);
        _input1.SetActive(true);
        _input2.SetActive(true);
        _input3.SetActive(true);
        
        _inputController();
    }
    public void _HowToPlayButtonClicked()
    {
        _PanelTutorial.SetActive(true);
        
        _Button2.SetActive(true);
    }
    public void _CreditsButtonClicked()
    {
        _PanelCredits.SetActive(true);
        _Button1.SetActive(true);
    }

    public void _inputController()
    {
        _inputPName.interactable = false;
        _inputPNickname.interactable = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && _inputPName.interactable == false && _inputPNickname.interactable == false)
        {
            //_stringad = _inputName.text();
            //_Scene1Data._st1 = _stringad;
            PlayerPrefs.SetString("_KKad", _inputName.text);
            //deneme1.text = _inputName.text;
            _inputName.interactable = false;
            _inputPName.interactable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && _inputName.interactable == false && _inputPNickname.interactable == false)
        {
            //_stringkarakterad = _inputPName.text();
            //_Scene1Data._st2 = _stringkarakterad;
            PlayerPrefs.SetString("_KKadP", _inputPName.text);
            _inputPName.interactable = false;
            _inputPNickname.interactable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && _inputName.interactable == false && _inputPName.interactable == false)
        {
            //_stringkarakternick = _inputPNickname.text();
            _inputPNickname.interactable = false;
            PlayerPrefs.SetString("_KKadPN", _inputPNickname.text);
            //_Scene1Data._st3 = _stringkarakternick;

            SceneManager.LoadScene("Scene2");
        }
    }
}
