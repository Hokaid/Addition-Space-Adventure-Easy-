using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meteoritos : MonoBehaviour
{
    public List<GameObject> GOMeteorites, Vidas; public GameObject Nave; List<int> numbers; 
    Transform pos; Transform TNave; public List<Text> TextNumbers;
    int movcounter = 0, numberi, addition, mode = 1, score = 0, vidas = 3, velocidad = 16; bool choconave = false;
    public Text Operation, Score; Color red, green, violet; float posinitx; GameController gc;
    void Start() {
    	red = new Color(1.0f, 0.0f, 0.0f);
    	green = new Color(0.0f, 1.0f, 0.0f);
    	violet = new Color(1.0f, 0.0f, 1.0f);
    	numbers = new List<int>();
    	for (int i=0; i < 3; i++) {
    		numbers.Add(0);
    	}
    	AsignarNumeros();
    	pos = gameObject.GetComponent<Transform>();
    	posinitx = pos.position.x;
    	TNave = Nave.GetComponent<Transform>();
    	gc = GameObject.FindWithTag("GameController").GetComponent<GameController>(); 
    }
    void Update() {
    	if (vidas > 0){
    		Mover();
    		ColsionNave();
    	} else {
    		SceneManager.LoadScene("GameOver");
    	}
    }
    void Mover(){
    	if (movcounter == velocidad){
    		movcounter = 0;
    		if (pos.position.x <= -200.0f){
    			foreach (GameObject gom in GOMeteorites) gom.SetActive(true);
    			pos.position = new Vector3(posinitx, pos.position.y, 0.0f);
    			if (mode != 3) { AsignarNumeros(); }
    			else { AsignarNumerosResult(); }
    			choconave = false;
    		}
    		pos.position = pos.position + new Vector3(-20.0f, 0.0f, 0.0f);
    	}
    	else{ movcounter++; }
    }
    void ColsionNave(){
    	if (pos.position.x <= -100.0f){
    		if (!choconave){
    		switch (TNave.position.y) {
    			case 2.0f: GOMeteorites[2].SetActive(false); choconave = true; DefineOperation(numbers[2]); break;
    			case -0.5f: GOMeteorites[1].SetActive(false); choconave = true; DefineOperation(numbers[1]); break;
    			case -3.0f: GOMeteorites[0].SetActive(false); choconave = true; DefineOperation(numbers[0]); break;
    		}
    		if (mode!=3) { mode++; } else { mode = 1; } 
    	}
    	}
    }
    void AsignarNumeros(){
        for (int i=0; i < numbers.Count; i++){
        	numbers[i] = Random.Range(0, 11);
        	TextNumbers[i].text = numbers[i].ToString();
        }
    }
    void AsignarNumerosResult(){
    	int resultidx = Random.Range(0, 3);
        for (int i=0; i < numbers.Count; i++){
        	if (i != resultidx) { numbers[i] = Random.Range(0, 21); }
        	else { numbers[i] = addition+numberi; }
        	TextNumbers[i].text = numbers[i].ToString();
        }
    }
    void DefineOperation(int number){
    	switch (mode){
    		case 1:
    		Operation.color = violet;
    		numberi = number;
    		Operation.text = numberi.ToString() + "+X=X";
    		break;
    		case 2:
    		addition = number;
    		Operation.text = numberi.ToString() + "+" + addition.ToString() + "=X";
    		break;
    		case 3:
    	    Operation.text = numberi.ToString() + "+" + addition.ToString() + "="+ number.ToString();
    	    if (number == numberi+addition){
    	    	Operation.color = green;
    	    	score = score + 5; Score.text = "Score: " + score.ToString(); gc.score = score;
    	    } else {
    	    	Operation.color = red;
    	    	vidas = vidas - 1;
    	    	Vidas[vidas].SetActive(false);
    	    }
    	    if (velocidad > 4) velocidad-=1;
    	    break;
    	}
    }
}
