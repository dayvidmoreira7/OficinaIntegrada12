using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Celular : MonoBehaviour {

	public List<Material> objetivo;
	public List<Material> mensagem;
	public List<Material> temperatura;
	public List<Transform>	objeto;

	public AudioClip somMensagem;

	public MeshRenderer tela;

	public int indiceObj;
	public int indiceMsg;
	int indiceTmp;
	int olharTela = 1;

	Material thisObj;
	Material thisMsg;
	Material thisTmp;

	public bool tocarSom = false;

	float x;
	float z;

	void Start () 
	{
		indiceObj = 0;
		indiceMsg = 0;
		indiceTmp = 0;
	}
	
	void Update () 
	{
		thisObj = objetivo [indiceObj];
		thisMsg = mensagem [indiceMsg];
		thisTmp = temperatura [indiceTmp];
		x = objeto [indiceObj].position.x - this.transform.position.x;
		z = objeto [indiceObj].position.z - this.transform.position.z;

		if(Input.GetKeyDown(KeyCode.Alpha1))	olharTela = 1;
		if(Input.GetKeyDown(KeyCode.Alpha2))	olharTela = 2;
		if(Input.GetKeyDown(KeyCode.Alpha3))	olharTela = 3;

		if(x < 200f && x > -200f && z < 200f && z > -200f)
		{
			indiceTmp = 0;
			if(x < 40f && x > -40f && z < 40f && z > -40f)
			{
				indiceTmp = 1;
				if(x < 10f && x > -10f && z < 10f && z > -10f)
				{
					indiceTmp = 2;
				}
			}
		}
		

		switch(olharTela)
		{
		case 1:
			tela.material = thisMsg;
			break;
		case 2:
			tela.material = thisObj;
			break;
		case 3:
			tela.material = thisTmp;
			break;
		}

		if(tocarSom)
		{
			GetComponent<AudioSource>().PlayOneShot(somMensagem);
			tocarSom = false;
		}
	}
}
