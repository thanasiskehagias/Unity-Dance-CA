using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Audio;
using System.IO;

namespace TMPro.Examples
{
    public class Poem01 : MonoBehaviour
    {
		//public AudioClip clip; 	
		public ClipReader clipReader; 
		public GameObject Music;
		public float TruLength;	
		public float ClipLength;	
        public enum objectType { TextMeshPro = 0, TextMeshProUGUI = 1 };

        public objectType ObjectType;
        public bool isStatic;
		public string[] PoemLines;
		public int PoemLinesNum=0; 

		public Light spotlight0;
		public Light spotlight1;
		public Light spotlight2;
		public GameObject Tower;
		public GameObject Oracle;
		public Camera camera;
		//public GameObject Music;
		
        private TMP_Text m_text;
        private const string k_label = ""; //"The count is <#0080ff>{0}</color>";
        private int count;
		int TIME;
		int REST;
		int n;
        void Awake()
        {
			TIME=0;
			TruLength=100000;
			n=-1;
            if (ObjectType == 0)
                m_text = GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();
            else
                m_text = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
				m_text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Anton SDF");
				m_text.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Anton SDF - Outline");
				m_text.color = new Color32(255, 255, 255, 255);
				m_text.fontSize = 5;
				m_text.alignment = TextAlignmentOptions.Center;
				m_text.text = ".                                                                                                                                                          ."; //A <#0080ff>simple</color> line of text.";
				Vector2 size = m_text.GetPreferredValues(Mathf.Infinity, Mathf.Infinity);
				m_text.rectTransform.sizeDelta = new Vector2(size.x, size.y);
        }
		void Start()
		{
		   StreamReader inp_stm = new StreamReader(Application.dataPath + "/StreamingAssets/Poem.txt");
		   while(!inp_stm.EndOfStream)
		   {
			   string inp_ln = inp_stm.ReadLine( );
			   PoemLines[PoemLinesNum]=inp_ln;
			   PoemLinesNum+=1;
		   }
		   inp_stm.Close( );
		   print(PoemLinesNum+" lines in the poem");		   
		}
        void Update()
        {
			clipReader = Music.GetComponent<ClipReader>();
			ClipLength=clipReader.MYLength;
			if(ClipLength>0) TruLength=ClipLength;
			if(Mathf.Abs(Time.time-TIME*TruLength/PoemLinesNum)<0.1)
			{
				TIME=TIME+1; 
				n=n+1;
				if(n==30) n=-1;
				else m_text.SetText(PoemLines[n], TIME);
				print(TIME);
			}
			if(Time.time<16f)
			{
				spotlight0.intensity=0.25f*Time.time;
				spotlight1.intensity=0.25f*Time.time;
				spotlight2.intensity=0.25f*Time.time;
			}
			else if(Time.time>TruLength-12)
			{
				spotlight0.intensity-=0.01f;
				spotlight1.intensity-=0.01f;
				spotlight2.intensity-=0.01f;
			}
			if(Time.time>TruLength)
			{
				Music.SetActive(false);
				Tower.SetActive(false);
			}
			if(Time.time>TruLength+1f)
			{
				camera.gameObject.transform.position=new Vector3(1000f,-100f,1000f);
			}
			if(Time.time>TruLength+5f)
			{
				Application.Quit();
			}
        }
	}
}
