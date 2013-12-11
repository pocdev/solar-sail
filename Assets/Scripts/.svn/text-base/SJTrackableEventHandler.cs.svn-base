using UnityEngine;
using System.Collections;

public class SJTrackableEventHandler : DefaultTrackableEventHandler 
{
	public string levelToLoad;
	
	bool _doLoading = true;
	
	// Use this for initialization
	protected override void Start () 
	{
		if(Application.platform != RuntimePlatform.OSXEditor)
			levelToLoad = SystemInfo.deviceModel.Contains("iPhone") ? "iPhone" : "iPad";
				
		base.Start();
	}
	
	protected override void OnTrackingFound()
	{
		StartCoroutine(loadLevel());
	}
	
	protected override void OnTrackingLost()
	{
		base.OnTrackingLost();
	}
	
	IEnumerator loadLevel()
	{
		if(_doLoading)
		{	
			AsyncOperation async = Application.LoadLevelAdditiveAsync(levelToLoad);
			yield return async;
			
			GetComponent<AnimationController>().Subscribe();
			
			//TODO: Add AR Camera to the UI Manager.
			UIManager mgr = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
			mgr.AddCamera(Camera.main,Camera.main.cullingMask,Mathf.Infinity,1);
			
			_doLoading = false;
		}
		
		base.OnTrackingFound();
	}
}
