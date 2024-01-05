using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int currentScore = 0;
    public Text score;
    public float spawnInterval = 60f;
    public int requireScore;
    public GameOver gameover;
    public GameObject john;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (john.GetComponent<JohnMovement>().IsDie)
        {
            OnGameLose();
            return;
        }
        score.text = "Score: " + currentScore.ToString();
        if (currentScore > requireScore)
        {
            OnGameWin();
        }
    }

    public void OnGameWin()
    {
        gameover.ShowWin(currentScore);
    }

    public void OnGameLose()
    {
        gameover.ShowLose();
    }
}
