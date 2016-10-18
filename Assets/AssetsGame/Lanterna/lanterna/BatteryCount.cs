using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatteryCount : MonoBehaviour {

	public int numeroBaterias;
	public Text eae;

	void Start ()
	{
		numeroBaterias = 0;
	}
	
	void Update () 
	{
		gameObject.GetComponent<Text> ().text = numeroBaterias.ToString() + "/5";

		if(numeroBaterias == 0)
		{
			eae.color = Color.red;
		}
		else if(numeroBaterias == 5)
		{
			eae.color = Color.green;
		}
		else
		{
			eae.color = Color.white;
		}
	}
}
