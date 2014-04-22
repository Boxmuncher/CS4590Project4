using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GameObject glass = GameObject.Find("Glass");
		Color color = renderer.material.color;
		color.a = 0.5f;
		glass.renderer.material.color = color;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
