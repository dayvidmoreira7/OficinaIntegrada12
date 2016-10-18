using UnityEngine;
using System.Collections;

public class Pickable1 : MonoBehaviour {

	public GameObject Txt1;
	public GameObject Apoio;
	public bool txtAppear1 = false;
	public bool onHand1 = false;
	public bool readyToPick1 = false;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if(readyToPick1)
		{
			if(Input.GetKey(KeyCode.E))
			{
				onHand1 = true;
				txtAppear1 = false;
			}
		}

		if(onHand1)
		{
			this.transform.parent = GameObject.Find("FPSController").transform;
			this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
			this.transform.position = Apoio.GetComponent<Transform>().position;
			this.transform.rotation = Apoio.GetComponent<Transform>().rotation;
			this.transform.localScale = Apoio.GetComponent<Transform>().localScale;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}

		if(txtAppear1)
		{
			Txt1.SetActive(true);
		}
		else
		{
			Txt1.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		readyToPick1 = true;
		if(!onHand1)
		{
			txtAppear1 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		readyToPick1 = false;
		txtAppear1 = false;
	}
}
