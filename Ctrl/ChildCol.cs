using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCol : MonoBehaviour
{

	Color Target;
	GameObject TargetG;
	Color Mycolor;
	int num;

	// Use this for initialization
	void Start()
	{
		Mycolor = gameObject.GetComponentInParent<SpriteRenderer>().color;
		num = gameObject.GetComponentInParent<Block>().num;

	}

	// Update is called once per frame
	public void bye()
	{
		if (Target == Mycolor)
		{
			TargetG.GetComponent<Block>().Bye();
		}

	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 8)
		{
			Target = collision.GetComponent<SpriteRenderer>().color;
			TargetG = collision.gameObject;
		}



		//else Target = Color.white;
	}


	public Color GetTarget()
	{
		return Target;
	}

	//public void DestoryTarget(){
	//	TargetG.
	//}
}
