using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swtich : MonoBehaviour
{
	private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

	private Vector3 A;
	private Vector3 B;

	private GameObject G_a;
	private GameObject G_b;
	private bool selected;
	private GameManager GM;
	public Camera CM;
	void Start()
	{
		GM = GameObject.Find("Ctrl").GetComponent<GameManager>();
		selected = false;
		G_a = G_b = null;
		//camera_object = gameObject.GetComponent<Camera>();


	}
	private float StartTime = 0;

	void Update()
	{
		if (GM.isPause) return;
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
			RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 100);

			StartTime += Time.deltaTime;
			//なにかと衝突した時だけそのオブジェクトの名前をログに出す
			if (hit.collider)
			{
				if (!selected)
				{
					selected = true;
					G_a = hit.collider.gameObject;
					G_a.transform.Find("Point").GetComponent<ParticleSystem>().Play();
				}

				else if (G_a != null)
				{
					G_a.transform.Find("Point").GetComponent<ParticleSystem>().Stop();
					selected = false;
					G_b = hit.collider.gameObject;
					SwitchTwo(G_a, G_b);
					G_a = G_b = null;
				}
				else
				{
					selected = true;
					G_a = hit.collider.gameObject;

				}
				Debug.Log(hit.collider.gameObject.name);
			}

			Debug.DrawRay(ray.origin, ray.direction, Color.red, 100, true);
		}
	}

	private void SwitchTwo(GameObject a, GameObject b)
	{
		if (a == null || b == null)
		{
			return;
		}
		Vector2 Va = new Vector2(a.transform.position.x, a.transform.position.y);
		Vector2 Vb = new Vector2(b.transform.position.x, b.transform.position.y);

		if ((Va.x == Vb.x) && ((Va.y - Vb.y < 1.5f) && (Va.y - Vb.y > -1.5f)))  //移動範囲を制御する
		{
			a.transform.position = Vb;
			b.transform.position = Va;

		}
		else if ((Va.y == Vb.y) && ((Va.x - Vb.x < 1.5f) && (Va.x - Vb.x > -1.5f)))
		{
			a.transform.position = Vb;
			b.transform.position = Va;

		}


	}
}
