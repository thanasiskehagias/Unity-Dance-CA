﻿#pragma strict
import System.IO;
//import System.Diagnostics;

var StartName:String;
var StartCode:String;
var UpdateName:String;
var UpdateCode:String;
var Music:GameObject;
var MusicScript:BGMLoader;
var MusicFile:String;
var Site:GameObject;
var Oracle:GameObject;
var Dancer:GameObject;
var Sites:GameObject[];
var Dancers:GameObject[];
var AniConts:Animator[];
var Root:GameObject;
var Values:int[];
var ValuesOld:int[];
var CARule:int[];
var NSites:int;
var TIME:int;
var REST=100;
var n:int;
var m:int;
var xm:int;
var x0:int;
var xp:int;
function Awake() 
{
	StartName="DanceFloor01Start.txt";
	StartCode=ReadScript(StartName);
	UpdateName="DanceFloor01Update.txt";
	UpdateCode=ReadScript(UpdateName);

	eval(StartCode);
	MusicScript.targetFilename=MusicFile;
	for(n=0;n<NSites;n++)
	{
		Sites[n]=Instantiate(Site,Vector3(n,-1,0),Quaternion.identity);
		Sites[n].transform.parent=Root.transform;
		Dancers[n]=Instantiate(Dancer,Vector3(n,0,0),Quaternion.identity);
		Dancers[n].transform.parent=Root.transform;
		Values[n]=0;		
		AniConts[n]=Dancers[n].GetComponent(Animator);
		if(n==10) Values[n]=1;
		if(Values[n]==1) Sites[n].transform.localScale=Vector3(1.0,0.1,1.0);
	}
	Destroy(Dancer);

}
function Update () 
{
	eval(UpdateCode);
}
function ReadScript(ScriptName:String):String
{
	var ScriptCode:String;
	var fn=Application.dataPath + "/StreamingAssets/"+ScriptName;
	if(System.IO.File.Exists(fn)){var sr0 = new StreamReader(fn);ScriptCode = sr0.ReadToEnd(); sr0.Close();}
	//print(ScriptCode);
	return ScriptCode;
}
