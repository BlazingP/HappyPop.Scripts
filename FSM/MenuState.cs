using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
	public GameObject Deco;
	private void Awake()
	{
		stateID = StateID.Menu;
		AddTransition(Transition.StartButtonClick, StateID.Play); //从start转换到Play
		Deco = GameObject.Find("Deco").gameObject;
	}
	public override void DoBeforeEntering()
	{
		ctrl.view.ShowMenu();
		ctrl.cameraManager.ZoomOut();
		Deco.SetActive(false);
	}
	public override void DoBeforeLeaving()
	{
		ctrl.view.HideMenu();
	}
	public void OnStartButtonClick()
	{
		fsm.PerformTransition(Transition.StartButtonClick);

	}
	public void RebButtonClick()
	{
		fsm.PerformTransition(Transition.RebButtonClick);
	}
}

