using UnityEngine;
using System.Collections;

public class LookinDoor : MonoBehaviour {

	bool olhandoPorta;
	GameObject porta;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(olhandoPorta)
		{
			porta.GetComponent<OpenCloseDoor>().enabled = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.GetComponent<OpenCloseDoor>() != null)
		{
	//		col.GetComponent<OpenCloseDoor>().enabled = true;
			porta = GameObject.Find(col.name);
			olhandoPorta = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.GetComponent<OpenCloseDoor>() != null)
		{
	//		col.GetComponent<OpenCloseDoor>().enabled = false;
			olhandoPorta = false;
		}
	}
}
