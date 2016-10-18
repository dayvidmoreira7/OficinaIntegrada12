using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {

	public float energy;
	public GameObject lanterna;
	public bool power = false;
	public GameObject Baterias;
	public bool recarregar = false;
	public bool recarregando = false;

	public bool tocarSom;

	void Start () 
	{
		energy = 5f;
	}
	
	void Update () 
	{
		if(lanterna.GetComponent<Pickable>().onHand)
		{
			if(Input.GetKeyDown(KeyCode.F) && !power)
			{
				power = true;
				tocarSom = true;
			}
			else if(Input.GetKeyDown(KeyCode.F) && power)
			{
				power = false;
				tocarSom = true;
			}

			if(lanterna.GetComponent<Pickable>().onHand && Baterias.GetComponent<BatteryCount>().numeroBaterias == 0)
			{
				recarregar = false;
			}
			else
			{
				recarregar = true;
			}
			
			if(Input.GetKeyDown(KeyCode.R) && recarregar)
			{
				recarregando = true;
			}
			if(recarregando && Input.anyKeyDown)
			{
				energy = 8f;
				Baterias.GetComponent<BatteryCount>().numeroBaterias -= 1;
				recarregando = false;
			}
		}

		if(power)
		{
			energy -= 0.001f;
			gameObject.GetComponent<Light>().intensity = energy;
			if(energy < 0f)
			{
				energy = 0f;
			}
		}
		else
		{
			gameObject.GetComponent<Light>().intensity = 0f;
		}
	}
}
