using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool1
{

	public static Vector2 Round(this Vector3 v)   //三维转二维 取整数
	{
		int x = Mathf.RoundToInt(v.x);
		int y = Mathf.RoundToInt(v.y);
		return new Vector2(x, y);
	}

}
