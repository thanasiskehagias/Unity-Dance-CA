///////////////////////////////////////////////////////////////////////
// Borrowed from the Csharp2.cs script of the following
//                                                   
// Unity3D: JavaScript->C# or C#->JavaScript access         
// Created by DimasTheDriver in 18/Dez/2010                 
// Part of 'Unity3D: JavaScript->C# or C#->JavaScript access' post.
// Availiable at:       http://www.41post.com/?p=1935              
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ClipReader : MonoBehaviour 
{
	private BGMLoader jsScript;
	public float MYLength; 	
	
	
	void Awake()
	{
		jsScript = this.GetComponent<BGMLoader>();//Don't forget to place the 'JS1' file inside the 'Standard Assets' folder
		MYLength=jsScript.MyLength;
	}
	void Update()
	{
		MYLength=jsScript.MyLength;
	}
	
	/*
	//render text and other GUI elements to the screen
	void OnGUI()
	{
		//render the JS1 'message' variable
		GUI.Label(new Rect(10,10,300,20),MYLength.ToString());
	}
	*/

}
