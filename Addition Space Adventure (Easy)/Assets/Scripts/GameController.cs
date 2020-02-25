using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public int score = 0;
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}

    public void Play(){
    	 SceneManager.LoadScene("Game");
    }
}
