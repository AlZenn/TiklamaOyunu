using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Screen4Controller : MonoBehaviour
{
    public Button _NextLevel;

    private void Start()
    {
        _NextLevel = GameObject.Find("Buttonn").GetComponent<Button>();
        _NextLevel.onClick.AddListener(_nextLevel);
    }

    void _nextLevel()
    {
        SceneManager.LoadScene("Scene5");
    }

}
