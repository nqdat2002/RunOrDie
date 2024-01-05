using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject setting;
    public GameObject highscore;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void HigeScore()
    {
        setting.SetActive(false);
        menu.SetActive(false);
        highscore.SetActive(true);
    }

    public void Setting()
    {
        setting.SetActive(true);
        menu.SetActive(false);
        highscore.SetActive(false);
    }
    public void Back()
    {
        menu.SetActive(true);
        highscore.SetActive(false);
        setting.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
