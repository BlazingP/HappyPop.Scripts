using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{

	private Camera mainCamera;
	private void Awake()
	{
		mainCamera = Camera.main;
	}

	public void ZoomIn()  //PlayGame
	{
		//	mainCamera.DOFieldOfView(77f, 0.5f);
		mainCamera.DOOrthoSize(8f, 1f);

		mainCamera.DOColor(new Color(0.2705882f, 0.3254902f, 0.3215686f), 1);

		mainCamera.transform.DOLocalMove(new Vector3(5.23f, 6f, -9.84f), 0.5f);
		//	mainCamera.DOShakePosition(1, new Vector3(3, 3, 0));  //预计在从新开始时候加入
	}
	public void ZoomOut()//PAUSEGAME
	{
		mainCamera.DOOrthoSize(20f, 1f);
		mainCamera.DOFieldOfView(84f, 0.5f);                             //指定相机size ，时间。
		mainCamera.DOColor(new Color(98, 117, 116), 0.5f);
		//	mainCamera.transform.DORotate(new Vector3(-7.8f, 0, 0), 0.5f);

	}



}
