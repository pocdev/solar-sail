using UnityEngine;
using System.Collections;
using System;

public class DismissPopup : MonoBehaviour {
	
	public event Action onDismissed;
	
	private UIBistateInteractivePanel _panel;
	
	void Start () {
		_panel = GameObject.FindGameObjectWithTag("PopupPanel").GetComponent<UIBistateInteractivePanel>();
		GetComponent<UIButton>().SetValueChangedDelegate(onClick);
		
		if(Application.loadedLevelName != "Main")
			_panel.BringIn();
	}
	
	void onClick(IUIObject obj)
	{
		_panel.Dismiss();
		
		if(onDismissed != null)
			onDismissed();
	}
}
