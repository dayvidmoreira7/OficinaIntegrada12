using UnityEngine;
using System.Collections;

public class GuardarPegar : MonoBehaviour {

	bool usando = true;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Tab) && !usando)
		{
			usando = true;
		}
		else if(Input.GetKeyDown(KeyCode.Tab) && usando)
		{
			usando = false;
		}

		gameObject.GetComponent<Animator> ().SetBool ("Pegar", usando);
	}
}
