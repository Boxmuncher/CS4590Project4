using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {

	GameObject glass;
	GameObject Arrow;
	GameObject Book1;
	GameObject Player;
	GameObject Text;
	GameObject X;
	GameObject[] Arrows;
	public AudioClip searching;
	public AudioClip notification;
	public AudioClip negative;
	public AudioSource ambientChannel;
	public AudioSource alarmChannel;
	public AudioSource sonificationChannel;


	float startTime;
	int step = 1;
	bool firstEvent = false;
	// Use this for initialization
	void Start () {
		X= GameObject.Find("X");
		Text = GameObject.Find("Text");
		glass = GameObject.Find("Glass");
		Arrow = GameObject.Find("Arrow");
		Book1 = GameObject.Find("Book1");
		Player = GameObject.Find("Player");
		Arrows = GameObject.FindGameObjectsWithTag("Arrow");
		Color color = renderer.material.color;
		color.a = 0.5f;
		Text.renderer.enabled = false;
		X.renderer.enabled = false;
		glass.renderer.material.color = color;
		foreach(GameObject g in Arrows){
			g.renderer.enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Alpha1)){
			X.renderer.enabled = false;
			Text.renderer.enabled = false;
			firstEvent = false;
			alarmChannel.Stop();
			ambientChannel.Stop();
			sonificationChannel.Stop();
			foreach(GameObject g in Arrows){
				g.renderer.enabled = false;
			}
			alarmChannel.clip = negative;
			alarmChannel.Play();

		}
		Arrow.transform.Rotate(0, -50*Input.GetAxis("Horizontal")*Time.deltaTime, 0);
		if(Input.GetKey(KeyCode.F))
		{
			firstEvent = true;
			startTime = Time.time;

		}
		if(firstEvent){
			X.renderer.enabled = true;
			if(step ==1)
			{

				if(Time.time-startTime>=7 && ambientChannel.isPlaying){
					step++;
					alarmChannel.clip = notification;
					alarmChannel.Play();
				}
				else if(!ambientChannel.isPlaying){
					Text.renderer.enabled = true;
					ambientChannel.clip = searching;
					ambientChannel.Play();

				}

					

			}
			else if(step==2){
				Text.renderer.enabled = false;
				foreach(GameObject g in Arrows){
					g.renderer.enabled = true;
				}

				if(Vector3.Distance(Player.transform.localPosition,Book1.transform.localPosition)<=20){
					step++;
					foreach(GameObject g in Arrows){
						g.renderer.enabled = false;
					}
				}
			}
			else if(step==3){
				if(Input.GetKey(KeyCode.R))
				{
					//Get a review
				}
				else if(Input.GetKey(KeyCode.P))
				{
					//Read a passage
				}

			}

		}
	}
}
