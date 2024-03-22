using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screen3Controller : MonoBehaviour
{
    public Text text1, text2, text3;
    public Button buttonDevam;
    public Screen1Controller firstSc;

    private void Start()
    {
        text1 = GameObject.Find("TextKullaniciAdSoyad").GetComponent<Text>();
        text2 = GameObject.Find("TextKarakterAdSoyad").GetComponent<Text>();
        text3 = GameObject.Find("TextKarakterNickname").GetComponent<Text>();
        buttonDevam = GameObject.Find("Buttonn").GetComponent<Button>();
        buttonDevam.onClick.AddListener(NextLevelScene3);
        firstSc = FindObjectOfType<Screen1Controller>();
    }

    private void Update()
    {
        text1.text = PlayerPrefs.GetString("_KKad");
        text2.text = PlayerPrefs.GetString("_KKadP");
        text3.text = PlayerPrefs.GetString("_KKadPN");

    }

    void NextLevelScene3()
    {
        SceneManager.LoadScene("Scene4");
    }
}
