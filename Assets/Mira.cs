using UnityEngine;
using System.Collections;

public class Mira : MonoBehaviour {

	public Texture2D mira;
	bool jogando = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(jogando)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect ((Screen.width/2) - (mira.width/4), (Screen.height/2) - (mira.height/4), mira.width/2, mira.height/2), mira);
	}
}
