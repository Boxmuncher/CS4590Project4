using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {

	GameObject glass;
	GameObject Arrow;

	GameObject Player;
	GameObject Text;
	//GameObject X;
	GameObject[] Arrows;
	int selectedTab;
	GameObject selector;
	public AudioClip searching;
	public AudioClip notification;
	public AudioClip negative;
	public AudioClip pageTurn;
	public AudioSource ambientChannel;
	public AudioSource alarmChannel;
	public AudioSource sonificationChannel;
	public Transform Book1;

	float startTime;
	int step = 1;
	bool firstEvent = false;
	bool secondEvent = false;
	bool thirdEvent = false;
	// Use this for initialization
	void Start () {
		//X= GameObject.Find("X");
		Text = GameObject.Find("Text");
		glass = GameObject.Find("Glass");
		selector = GameObject.Find("Selector");
		Arrow = GameObject.Find("Arrow");

		Player = GameObject.Find("Player");
		selectedTab = 1;

		Arrows = GameObject.FindGameObjectsWithTag("Arrow");

		Color color = renderer.material.color;
		color.a = 0.5f;
		Text.renderer.enabled = false;
//		X.renderer.enabled = false;
		glass.renderer.material.color = color;
		foreach(GameObject g in Arrows){
			g.renderer.enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(selectedTab==1){
				ambientChannel.PlayOneShot(pageTurn);
				selectedTab=2;
				Vector3 pos =selector.transform.localPosition;
				pos.x+=0.5f;

				selector.transform.localPosition = pos;
			}
			else if(selectedTab==2){
				ambientChannel.PlayOneShot(pageTurn);
				selectedTab=3;
				Vector3 pos =selector.transform.localPosition;
				pos.x+=0.45f;
				
				selector.transform.localPosition = pos;
			}
		}
		if(Input.GetKeyDown(KeyCode.O))
		{
			if(selectedTab==2){

				ambientChannel.PlayOneShot(pageTurn);
				selectedTab=1;
				Vector3 pos =selector.transform.localPosition;
				pos.x-=0.5f;
				
				selector.transform.localPosition = pos;
			}
			else if(selectedTab==3){
				ambientChannel.PlayOneShot(pageTurn);
				selectedTab=2;
				Vector3 pos =selector.transform.localPosition;
				pos.x-=0.45f;
				
				selector.transform.localPosition = pos;
			}
		}
		if(Input.GetKey(KeyCode.F))
		{
			startTime = Time.time;
			if(selectedTab==1){
				firstEvent = true;
				secondEvent = false;
				thirdEvent = false;
			}
			else if(selectedTab==2){
				secondEvent = true;
				firstEvent = false;
				thirdEvent = false;
			}
			else if(selectedTab==3){
				thirdEvent = true;
				firstEvent = false;
				secondEvent = false;
			}
		}

		if(Input.GetKey(KeyCode.Alpha1)){
			//X.renderer.enabled = false;
			Text.renderer.enabled = false;
			firstEvent = false;
			secondEvent = false;
			thirdEvent = false;
			alarmChannel.Stop();
			ambientChannel.Stop();
			sonificationChannel.Stop();
			foreach(GameObject g in Arrows){
				g.renderer.enabled = false;
			}	
			alarmChannel.clip = negative;
			alarmChannel.Play();

		}
		Arrow.transform.LookAt(Book1,new Vector3(0,1,0));

		if(firstEvent){
			//X.renderer.enabled = true;
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
				Vector3 distanceVector = Book1.transform.localPosition - Player.transform.localPosition;
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
