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

	public void ZoomIn()  //放大
	{
		mainCamera.DOFieldOfView(77f, 0.5f);

		mainCamera.DOColor(Color.cyan, 1);
		mainCamera.transform.DORotate(new Vector3(-3f, 0, 0), 0.5f);
		//	mainCamera.DOShakePosition(1, new Vector3(3, 3, 0));  //预计在从新开始时候加入
	}
	public void ZoomOut()//缩小
	{
		mainCamera.DOFieldOfView(84f, 0.5f);                             //指定相机size ，时间。
		mainCamera.DOColor(Color.white, 0.5f);
		mainCamera.transform.DORotate(new Vector3(-7.8f, 0, 0), 0.5f);

	}



}
