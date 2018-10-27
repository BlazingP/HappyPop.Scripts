using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{

	private RectTransform logoName;
	private RectTransform menuUI;
	private RectTransform gameUI;
	private GameObject restartButton;

	public GameObject test;
	void Awake()
	{
		logoName = transform.Find("Canvas/LogoName") as RectTransform;
		menuUI = transform.Find("Canvas/MeunUI") as RectTransform;
		gameUI = transform.Find("Canvas/GameUI") as RectTransform;
		test = GameObject.Find("Test");
		restartButton = transform.Find("Canvas/MeunUI/ReStartButton").gameObject;
	}

	public void ShowMenu()
	{
		logoName.gameObject.SetActive(true);
		logoName.DOAnchorPosY(-163f, 0.5f); // 运动Y 到 -163f位置 ，于0.5f秒后
		menuUI.gameObject.SetActive(true);
		menuUI.DOAnchorPosY(285f, 0.5f);
	}
	public void HideMenu()
	{
		logoName.DOAnchorPosY(75.00006f, 0.5f)
				.OnComplete(delegate { logoName.gameObject.SetActive(false); });//.OnComplete（delegate 设置委托当前面的动作完成时激活
		menuUI.DOAnchorPosY(-115f, 0.5f)
			  .OnComplete(delegate { menuUI.gameObject.SetActive(false); });
		test.gameObject.SetActive(false);

	}

	public void ShowGameUI()
	{
		gameUI.gameObject.SetActive(true);
		gameUI.DOAnchorPosY(0f, 0.5f);

	}
	public void HideGameUI()
	{
		gameUI.DOAnchorPosY(313f, 0.5f)
			  .OnComplete(delegate { gameUI.gameObject.SetActive(false); });
	}
	public void ShowRestartButton()
	{
		restartButton.SetActive(true);
	}
}
