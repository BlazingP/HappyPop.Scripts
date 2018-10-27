using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public bool isPause = true;
	public GameObject makeMom;
	private Ctrl ctrl;
	private void Awake()
	{
		ctrl = GetComponent<Ctrl>();
	}
	void Start()
	{


	}
	public void StarGame()
	{
		isPause = false;
	}

	public void PauseGame()
	{
		isPause = true;
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.X))
		{
			isPause = true;
		}
		if (Input.GetKey(KeyCode.C))
		{
			isPause = false;
		}

	}

	void SpawnBlock()
	{

	}
}
