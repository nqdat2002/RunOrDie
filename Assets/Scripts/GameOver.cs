using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;
    public GameObject backImg;
    // Start is called before the first frame update
    public Text scoreText;
    public Text loseText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        backImg.SetActive(true);
        //loseText.enabled = false;
        loseText.text = "You Lose!";
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("GameOverShow");
        }
    }
    public void ShowWin(int score)
    {
        screenParent.SetActive(true);
        loseText.text = "You Win!";
        backImg.SetActive(true);
        scoreText.text = score.ToString();
        scoreText.enabled = false;
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("GameOverShow");
        }
    }
    public void OnReplayClicked()
    {
        Debug.Log("Pressed Replay");
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnDoneClicked()
    {
        Debug.Log("Pressed Done");
        // Todo
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
    }
}
