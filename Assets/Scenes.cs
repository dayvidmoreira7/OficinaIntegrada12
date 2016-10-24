using UnityEngine;
using System.Collections;

public class Scenes : MonoBehaviour {

	public GameObject _cima, _baixo, _escola, _itens;
	bool cima, baixo, escola, itens;

	void Start ()
	{
		cima = true;
		baixo = false;
		escola = false;
		itens = false;
	}
	
	void Update ()
	{
		if(cima)
		{
			_cima.SetActive(true);
		}
		else
		{
			_cima.SetActive(false);
		}

		if(baixo)
		{
			_baixo.SetActive(true);
		}
		else
		{
			_baixo.SetActive(false);
		}

		if(escola)
		{
			_escola.SetActive(true);
		}
		else
		{
			_escola.SetActive(false);
		}

		if(itens)
		{
			_itens.SetActive(true);
		}
		else
		{
			_itens.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "AparecerBaixo")
		{
			baixo = true;
		}
		if(col.name == "SumirBaixo")
		{
			baixo = false;
		}

		if(col.name == "AparecerCima")
		{
			cima = true;
		}
		if(col.name == "SumirCima")
		{
			cima = false;
		}

		if(col.name == "AparecerBaixo")
		{
			baixo = true;
		}
		if(col.name == "SumirBaixo")
		{
			baixo = false;
		}
		
		if(col.name == "AparecerEscola")
		{
			escola = true;
		}
		if(col.name == "SumirEscola")
		{
			escola = false;
		}

		if(col.name == "AparecerItens")
		{
			itens = true;
		}
		if(col.name == "SumirItens")
		{
			itens = false;
		}
	}
}
