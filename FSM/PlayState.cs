using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
	public AudioSource MPer;
	public GameObject Deco;
	private void Awake()
	{
		stateID = StateID.Play;
		AddTransition(Transition.PauseButtonClick, StateID.Menu);
		MPer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
		Deco = GameObject.Find("Deco").gameObject;

	}
	public override void DoBeforeEntering()   // 当激活时调用。
	{

		ctrl.view.ShowGameUI();
		ctrl.cameraManager.ZoomIn();
		ctrl.gameManager.StarGame();
		MPer.Play();
		Deco.SetActive(true);
	}
	public override void DoBeforeLeaving() // 取消激活调用
	{
		ctrl.view.HideGameUI();
		ctrl.view.ShowRestartButton();
		ctrl.gameManager.PauseGame();
		MPer.Pause();
		Deco.SetActive(false);
	}
	public void OnPauseButtonClick()
	{
		fsm.PerformTransition(Transition.PauseButtonClick);
	}

}
