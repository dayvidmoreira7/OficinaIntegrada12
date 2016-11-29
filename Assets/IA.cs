using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	private Animator anim;
	public GameObject lanterna;

	public BoxCollider b1;
	public BoxCollider b2;

	public bool andar;
	public bool define;
	public bool seguirPlayer = false;
	public bool lantPower;
	public int saida = 0;

	public Transform target;
	float f_RotSpeed=3.0f,f_MoveSpeed = 6.0f;

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

		if(andar && saida < 3 && !seguirPlayer)
		{
			Follow();
		}
		if(andar && seguirPlayer)
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
		if(!seguirPlayer)
		{
			target = GameObject.Find("SaidaRaposa" + saida.ToString()).transform;
			define = false;
		}
		else
		{
			target = GameObject.Find("FPSController").transform;
			define = false;
		}
	}
}
