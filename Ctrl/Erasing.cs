using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasing : MonoBehaviour
{

	[HideInInspector]
	public Color MyColor;
	private int Family;
	// Use this for initialization
	void Start()
	{
		MyColor = GetComponent<SpriteRenderer>().color;

	}
	private void OnTriggerStay(Collider other)
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
