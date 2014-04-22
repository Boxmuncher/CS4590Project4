using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour {

	GameObject glass;
	GameObject Arrow;
	// Use this for initialization
	void Start () {
		glass = GameObject.Find("Glass");
		Arrow = GameObject.Find("Arrow");
		Color color = renderer.material.color;
		color.a = 0.5f;
		glass.renderer.material.color = color;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
