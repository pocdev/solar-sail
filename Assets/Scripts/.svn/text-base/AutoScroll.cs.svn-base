using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UIScrollList))]
public class AutoScroll : MonoBehaviour {

	public float speed = 1f;
	
	private UIScrollList _scrollList;
	
	void Start()
	{
		_scrollList = GetComponent<UIScrollList>();	
	}
	
	void Update () 
	{
		//Debug.Log(_scrollList.ScrollPosition);
		_scrollList.ScrollListTo( Mathf.Clamp(_scrollList.ScrollPosition + (Time.deltaTime * speed),0f,1f)); 
		
		if(_scrollList.ScrollPosition >= 1f)
		{
			_scrollList.ScrollListTo(0f);
		}
		
	}
}
