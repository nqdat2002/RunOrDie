using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //public int requireScore;
    //public GameManager manager;
    //public GameObject grunt;
    //public GameObject john;
    //public static int currentScore = 0;
    //private bool _didWin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (grunt != null && grunt.GetComponent<GruntScript>().CurrentHealth == 0)
        //{
        //    currentScore += 150;
        //}
        //manager.SetScore(currentScore);
        //if (currentScore > requireScore)
        //{
        //    GameWin();
        //}
    }

    public void GameWin()
    {
        //Debug.Log("You Win.");
        //manager.OnGameWin(currentScore);
        //_didWin = true;
        //// StartCoroutine(Waits());
    }

    public void GameLose()
    {
        //Debug.Log("You Lose.");
        //manager.OnGameLose();
        //_didWin = false;
    }

}
