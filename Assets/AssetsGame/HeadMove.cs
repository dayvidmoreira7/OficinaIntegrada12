using UnityEngine;
using System.Collections;

public class HeadMove : MonoBehaviour {

	public GameObject lanterna;
	public GameObject player;
	public GameObject lanternaLuz;
	public GameObject mesh;

	bool subir = false;
	bool olhar = false;

	float tempoOlhar = 0f;

	void Start () 
	{
		
	}
	
	void Update ()
	{
		if(lanterna.GetComponent<Pickable>().onHand == true && tempoOlhar < 3f)
		{
			this.transform.rotation = Quaternion.Euler(new Vector3(0f, 3f, 0f));
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
			subir = true;
			gameObject.GetComponent<AudioSource>().enabled = true;
		}

		if(subir)
		{
			if(this.transform.position.y < 1.8f)
			{
				transform.Translate(Vector3.up * 0.3f * Time.deltaTime);
			}
			if(this.transform.position.y > 1.76f)
			{
				olhar = true;
				tempoOlhar += 1f * Time.deltaTime;
			}
		}

		if(olhar && tempoOlhar < 3f)
		{
			transform.LookAt(player.transform);
		}
		if(olhar && tempoOlhar > 3f)
		{
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			subir = false;
			olhar = false;
			gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * 880f, transform.position);
			mesh.GetComponent<AudioSource>().enabled = true;
			lanternaLuz.GetComponent<OnOff>().power = false;
			gameObject.GetComponent<HeadMove>().enabled = false;
		}
		
	}
}
