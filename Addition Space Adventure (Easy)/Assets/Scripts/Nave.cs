using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    Transform RectNave;
    void Start(){
    	RectNave = gameObject.GetComponent<Transform>();
    }
    void Update(){}
    public void Up(){
    	if (RectNave.position.y < 2.0f) RectNave.position = RectNave.position + new Vector3(0.0f, 2.5f, 0.0f);
    }
    public void Down(){
    	if (RectNave.position.y > -3.0f) RectNave.position = RectNave.position - new Vector3(0.0f, 2.5f, 0.0f);
    }
}
