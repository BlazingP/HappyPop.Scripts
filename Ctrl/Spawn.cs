using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	private bool isPause = false;
	public GameObject[] objects;
	public LayerMask _Block;
	GameManager GM;
	public void Start()
	{
		GM = GameObject.Find("Ctrl").GetComponent<GameManager>();

	}
	public void Update()
	{
		if (GM.isPause) return;

		Collider2D In = Physics2D.OverlapCircle(transform.position, 0.1f, _Block);
		if (In == null)
		{

			int rand = Random.Range(0, objects.Length);

			Instantiate(objects[rand], transform.position, Quaternion.identity);
		}

	}

}
