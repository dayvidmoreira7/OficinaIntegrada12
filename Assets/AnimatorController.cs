using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

	Animator anim;

	public GameObject baterryCount;
	BatteryCount bc;

	public GameObject lampada;
	OnOff oo;

	bool enabled = false;

	bool run = false;
	bool recharge = false;

	float counter = 0f;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		bc = baterryCount.GetComponent<BatteryCount> ();
		oo = lampada.GetComponent<OnOff> ();
	}
	
	void Update () 
	{
		if(GetComponent<Animator>().enabled == true)
		{
			enabled = true;
		}

		if(enabled)
		{
			if(Input.GetKey(KeyCode.LeftShift))
			{
				run = true;
			}
			else
			{
				run = false;
			}
			
			if(oo.recarregando)
			{
				counter += 1f * Time.deltaTime;
				lampada.GetComponent<Light>().enabled = false;
			}
			else
			{
				counter = 0f;
			}
			
			if(counter > 3.6f)
			{
				lampada.GetComponent<Light>().enabled = true;
				oo.energy = 8f;
				bc.numeroBaterias -= 1;
				oo.recarregando = false;
			}
			
			anim.SetBool ("Run", run);
			anim.SetBool ("Recharge", oo.recarregando);
		}
	}
}
