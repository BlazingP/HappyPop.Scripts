using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Block : MonoBehaviour
{
	[Header("Block图层")]
	public LayerMask block;
	public float distance;
	private Ctrl ctrl;
	private bool isPause = false;
	private float timer = 0;
	private float stepTIme = 0.1f;
	float PosY;
	public Transform groundCheck;
	GameManager GM;
	public bool BlockAru;
	[HideInInspector]
	public Color MyColor;
	private AudioSource MyAudio;
	public bool FamilyAru;
	//public Transform CheckPos;
	//public float CheckRange;

	private ChildCol[] ChildCol = new ChildCol[4];
	private GameObject[] Col = new GameObject[4];
	public Color[] colors = new Color[4]; //
	public int num;

	public int nownum;
	bool blockAru  //射出射线 检测下方 有没有 block   
	{
		get
		{
			Vector2 start = groundCheck.position;
			Vector2 end = new Vector2(start.x, start.y - distance);
			Debug.DrawLine(start, end, Color.blue);
			BlockAru = Physics2D.Linecast(start, end, block);
			return BlockAru;

		}

	}

	public void Kesu()
	{
		nownum++;
	}
	//bool familyAru
	//{
	//	get
	//	{

	//		Vector2 start = this.transform.position;
	//		Vector2 end = new Vector2(start.x, start.y - 2f);
	//		Debug.DrawLine(start, end, Color.green);
	//		RaycastHit hit;
	//		if (Physics2D.Linecast(start, end, out hit))
	//		{

	//			if (hit.collider.GetComponent<SpriteRenderer>.Color == MyColor)
	//			{

	//			}
	//		}
	//		return familyAru;
	//	}
	//}


	public void Start()
	{
		GM = GameObject.Find("Ctrl").GetComponent<GameManager>();
		MyColor = GetComponent<SpriteRenderer>().color;
		MyAudio = GetComponent<AudioSource>();
		ChildCol[0] = transform.Find("Tig_U").gameObject.GetComponent<ChildCol>();
		ChildCol[1] = transform.Find("Tig_D").gameObject.GetComponent<ChildCol>();
		ChildCol[2] = transform.Find("Tig_L").gameObject.GetComponent<ChildCol>();
		ChildCol[3] = transform.Find("Tig_R").gameObject.GetComponent<ChildCol>();

	}
	public void FixedUpdate()
	{
		PosY = transform.position.y;
		if (GM.isPause) return;

		timer += Time.deltaTime;
		if (timer > stepTIme && PosY > 1 && !blockAru)
		{
			timer = 0;
			Fall();
		}

		SetCol();
		num = 0;
		for (int i = 0; i < Col.Length; i++)
		{
			if (colors[i] == MyColor) num++;
		}
		//Debug.Log(num);
		//Collider2D[] ItsFamily = Physics2D.OverlapBoxAll(CheckPos.position, GetComponent<BoxCollider>().size / 2.0f, block);
		if (num >= 2 && Input.GetKeyDown(KeyCode.A))
		{

			GoodBye();

		}

	}

	public void Fall()
	{

		Vector3 pos = transform.position;
		pos.y -= 1;                          //滑落速度の設定
		transform.position = pos;

	}

	public void GoodBye()
	{
		MyAudio.Play();
		transform.Find("Tig_U").gameObject.GetComponent<ChildCol>().bye();
		transform.Find("Tig_D").gameObject.GetComponent<ChildCol>().bye();
		transform.Find("Tig_L").gameObject.GetComponent<ChildCol>().bye();
		transform.Find("Tig_R").gameObject.GetComponent<ChildCol>().bye();
		this.gameObject.transform.DOPunchPosition(new Vector3(0, 0, -0.3f), 0.5f); // 来回冲压
		this.gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0.5f)  //透明

			   .OnComplete(delegate { Destroy(gameObject); });
	}
	public void Bye()
	{
		this.gameObject.transform.DOPunchPosition(new Vector3(0, 0, -0.3f), 0.5f); // 来回冲压
		this.gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0.5f)  //透明

			   .OnComplete(delegate { Destroy(gameObject); });
	}
	//private void OnDrawGizmosSelected()
	//{
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawSphere(CheckPos.position, CheckRange);
	//}

	private void SetCol()
	{
		for (int i = 0; i < ChildCol.Length; i++)
		{
			colors[i] = ChildCol[i].GetTarget();
		}
	}
}
