using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	private Animator anim;
	public GameObject lanterna;

	public bool andar;
	public bool define;
	public bool lantPower;
	public int saida = 0;

	Transform target;
	float f_RotSpeed=3.0f,f_MoveSpeed = 8.0f;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	void Update () 
	{
		lantPower = lanterna.GetComponent<OnOff> ().power;

		if(define)
		{
			defineTarget();
		}

		if(andar && lantPower)
		{
			Follow();
		}

		if(andar && !lantPower && saida < 3 )
		{
			Follow();
		}

		if(saida == 3)
		{
			gameObject.SetActive(false);
			saida = 0;
			target = null;
		}

		anim.SetBool("Walk", andar);
	}

	void Follow()
	{
		/* Look at Player*/
		transform.rotation = Quaternion.Slerp (transform.rotation , Quaternion.LookRotation (target.position - transform.position) , f_RotSpeed * Time.deltaTime);
		
		/* Move at Player*/
		transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
	}

	void defineTarget()
	{
		if(lantPower && target.name != "SaidaRaposa0" || lantPower && target.name != "SaidaRaposa1" || 
		   lantPower && target.name != "SaidaRaposa2")
		{
			target = GameObject.Find("FPSController").transform;
			define = false;
		}

		if(!lantPower)
		{
			target = GameObject.Find("SaidaRaposa" + saida.ToString()).transform;
			define = false;
		}
	}
}
