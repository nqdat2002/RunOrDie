using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public ButtonPlayerPrefs[] buttons;

    public void OnButtonPress(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OnButtonBack()
    {
        SceneManager.LoadScene("Menu");
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
