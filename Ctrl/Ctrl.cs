using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{

	[HideInInspector]
	public Model model;
	[HideInInspector]
	public View view;

	private FSMSystem fsm;
	[HideInInspector]
	public CameraManager cameraManager;
	[HideInInspector]
	public GameManager gameManager;

	private void Awake()
	{
		model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
		view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
		cameraManager = GetComponent<CameraManager>();
		gameManager = GetComponent<GameManager>();
	}
	void Start()
	{
		MakeFSM();
	}


	void Update()
	{

	}
	void MakeFSM()
	{
		fsm = new FSMSystem();                     //-------------------通过这里设置FSM的默认页面 也就是 菜单页面 ，
		FSMState[] states = GetComponentsInChildren<FSMState>();
		foreach (FSMState state in states)
		{
			fsm.AddState(state, this);
		}
		MenuState s = GetComponentInChildren<MenuState>();   //----------------调用状态 执行状态跳转
		fsm.SetCurrentState(s);

	}
}