using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
	public Color Mycolor;
	public Transform CheckPos;
	private LayerMask block;
	public int unite;
	void Start()
	{
		Mycolor = gameObject.GetComponentInParent<SpriteRenderer>().color;

	}


	// Update is called once per frame
	void Update()
	{
		unite = 0;
		Collider2D[] ItsFamily = Physics2D.OverlapBoxAll(CheckPos.position, GetComponent<BoxCollider2D>().size, block);
		for (int i = 0; i < ItsFamily.Length; i++)
		{

			if (ItsFamily[i].GetComponent<SpriteRenderer>().color == Mycolor)
			{
				unite++;
				Debug.Log(ItsFamily[i].name);
			}
		}

	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(CheckPos.position, GetComponent<BoxCollider2D>().size);
	}
}
