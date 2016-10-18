using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	public GameObject canvasMenu;
	public GameObject camera;
	public GameObject player;

	bool playing = false;

	float toPlay = 0f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playing)
		{
			StartCoroutine (fadeOut ());
			toPlay += 1f * Time.deltaTime;
		}

		if(toPlay > 5f)
		{
			player.SetActive(true);
			Destroy(camera.gameObject);
		}
	}

	public void play()
	{
		playing = true;
		camera.GetComponent<Animator> ().SetBool ("play", true);
	}

	IEnumerator fadeOut()
	{
		CanvasGroup cg = canvasMenu.GetComponent<CanvasGroup> ();
		if(cg.alpha > 0f)
		{
			cg.alpha -= 1f * Time.deltaTime;
		}
		cg.blocksRaycasts = false;
		cg.interactable = false;

		yield return null;
	}
}
