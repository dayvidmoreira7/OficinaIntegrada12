using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

	public GameObject Txt;
	public GameObject Txt1;
	public GameObject playerHand;
	public GameObject panel; //panel1;
//	public GameObject imgPanel1;

	public Material batteryMat;

	public bool onHand = false;
	public bool readyToPick = false;
	public bool txtAppear = false;
	public bool txt1Appear = false;

	public float Txt1Desappear = 0f;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(readyToPick)
		{
			if(Input.GetKey(KeyCode.E))
			{
				onHand = true;
				txtAppear = false;
			}
		}

		if(txtAppear)
		{
			Txt.SetActive(true);
		}
		else
		{
			Txt.SetActive(false);
		}
		if(txt1Appear)
		{
			Txt1.SetActive(true);
			Txt1Desappear += 0.5f;
		}
		else
		{
			Txt1.SetActive(false);
			Txt1Desappear += 0f;
		}

		if(onHand)
		{
			panel.SetActive(true);

			GetComponent<Animator>().enabled = true;
			this.transform.parent = GameObject.Find("FPSController").transform;
			this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
			this.transform.position = playerHand.GetComponent<Transform>().position;
			this.transform.rotation = playerHand.GetComponent<Transform>().rotation;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;

			if(Txt1Desappear < 80f)
			{
				txt1Appear = true;
			}
			else
			{
				txt1Appear = false;
				batteryMat.shader = Shader.Find("Unlit/Texture");
			}
		}

		if(!onHand)
		{
			batteryMat.shader = Shader.Find("Standard");
		}
		else
		{
			batteryMat.shader = Shader.Find("Unlit/Texture");
		}
	}

	void OnTriggerEnter(Collider col)
	{
		readyToPick = true;
		if(!onHand)
		{
			txtAppear = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		readyToPick = false;
		txtAppear = false;
	}
}
