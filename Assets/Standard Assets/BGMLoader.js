#pragma strict
var targetFilename : String;
var urlBase : String;
var MyLength:float;
var TIME=0;
private var clip : AudioClip;
private function GetCachedFilePath() 
{
    return System.IO.Path.Combine(Application.temporaryCachePath, targetFilename);
}

function TryLoadAndPlay() 
{
//	var cachePath=Application.dataPath + "/StreamingAssets/Music.ogg";
	var cachePath=Application.dataPath + "/StreamingAssets/"+ targetFilename;
    var www = WWW("file:" + cachePath);
    yield www;

    if (www.error) 
	{
    } else 
	{
		clip = www.GetAudioClip(false, true);
		MyLength=clip.length;
        while (true) 
		{
            GetComponent.<AudioSource>().PlayOneShot(clip);
            yield WaitForSeconds(clip.length);
        }
    }
}


function Start() 
{
    yield TryLoadAndPlay();
    var www = WWW(urlBase + targetFilename);
    yield www;
    if (www.error) 
	{
    } else {
        System.IO.File.WriteAllBytes(GetCachedFilePath(), www.bytes);
        yield TryLoadAndPlay();
    }
}
/*
function LateUpdate() 
{
}
function OnGUI() {
}
*/