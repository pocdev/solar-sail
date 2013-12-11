using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
	
	public Material defaultMaterial;
	public Material hoverMaterial;
	public float hoverTime = 2f;
	
	private float _hoverTime = 0f;
	private bool _hovering = false;
	
	private HoverManager _hoverManager;
	private Gestures _gestures;
	
	// Use this for initialization
	void Start () 
	{
		if(GetComponent<UIButton3D>() != null)
			GetComponent<UIButton3D>().SetInputDelegate(onInput);
		_hoverManager = GameObject.FindGameObjectWithTag("HoverManager").GetComponent<HoverManager>();
	}

	void onInput(ref POINTER_INFO ptr)
	{
		if(_gestures == null)
			_gestures = GameObject.FindGameObjectWithTag("UserHitbox").GetComponent<Gestures>();
		
		switch(ptr.evt)
		{
			case POINTER_INFO.INPUT_EVENT.PRESS:
				_gestures.onBeginTouch();
				Debug.Log("STARTED TO HOVER!");
				_hovering = true;
				break;
			case POINTER_INFO.INPUT_EVENT.NO_CHANGE:
				if(_hovering)
				{
					_hoverTime += Time.deltaTime;
					if(_hoverTime >= hoverTime)
					{
						_hovering = false;
						_hoverTime = 0;
						doHover();
					}
				}
				break;
			default:
				_hovering = false;
				_hoverTime = 0;
				break;
		}
	}
	
	void doHover()
	{
		_hoverManager.doHover(tag);
	}
}
