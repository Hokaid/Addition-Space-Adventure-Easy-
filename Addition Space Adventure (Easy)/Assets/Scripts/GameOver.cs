using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	GameController gcontroller;
	public Text Score; 
    void Start()
    {
    	gcontroller = GameObject.FindWithTag("GameController").GetComponent<GameController>(); 
    	Score.text = "Score: " + gcontroller.score.ToString();
    }

    public void TryAgain(){
    	gcontroller.score = 0;
    	SceneManager.LoadScene("Game");
    }
}
