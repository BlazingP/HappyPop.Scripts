using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class Test : MonoBehaviour
{
	private bool isMouseDrag;
	Vector3 pos;
	public Vector3 screenPosition;
	public Vector3 offset;
	GameManager GM;

	void Start()
	{
		isMouseDrag = false;
		GM = GameObject.Find("Ctrl").GetComponent<GameManager>();
	}
	private void Update()
	{

	}
	void OnMouseDown()
	{

		screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
		isMouseDrag = true;

	}
	void OnMouseDrag()
	{

		if (isMouseDrag && !GM.isPause)
		{

			float fax = Input.mousePosition.x;
			float fay = Input.mousePosition.y;
			//Debug.Log("开始拖拽了");
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);



			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
			gameObject.transform.position = currentPosition;

			//	StartCoroutine(Cant());

		}
	}
	//IEnumerator Cant()
	//{
	//if ((Input.mousePosition.x - gameObject.transform.position.x) > 100 || (Input.mousePosition.y - gameObject.transform.position.y) > 100)
	//{
	//	OnMouseUp();    

	//}





	//yield return null;
	//}
	void OnMouseUp()
	{

		isMouseDrag = false;
	}
}