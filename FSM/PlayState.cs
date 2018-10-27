using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
	private void Awake()
	{
		stateID = StateID.Play;
		AddTransition(Transition.PauseButtonClick, StateID.Menu);

	}
	public override void DoBeforeEntering()   // 当激活时调用。
	{

		ctrl.view.ShowGameUI();
		ctrl.cameraManager.ZoomIn();
		ctrl.gameManager.StarGame();
	}
	public override void DoBeforeLeaving() // 取消激活调用
	{
		ctrl.view.HideGameUI();
		ctrl.view.ShowRestartButton();
		ctrl.gameManager.PauseGame();
	}
	public void OnPauseButtonClick()
	{
		fsm.PerformTransition(Transition.PauseButtonClick);
	}

}
