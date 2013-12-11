using UnityEngine;
using System.Collections;

public class HoverManager : MonoBehaviour 
{	
	public float transitionDuration = 2f;
	public float blurSpread = 0f;
	
	private BlurEffect _blurEffect;
	private UIBistateInteractivePanel _popupPanel;
	private DismissPopup _dismissButton;
	
	private bool _isTransitioned = false;
	
	private ArrayList _tagsToRevert; 
	
	void Start()
	{
		_tagsToRevert = new ArrayList();
		_blurEffect = Camera.main.GetComponent<BlurEffect>();
	}
	
	public void doHover(string tagName)
	{
		if(_isTransitioned)
			return;
		
		_isTransitioned = true;
	
		_tagsToRevert.Add(tagName);
		
		if(_popupPanel == null)
			_popupPanel = GameObject.FindGameObjectWithTag("PopupPanel").GetComponent<UIBistateInteractivePanel>();
		
		if(_dismissButton == null)
		{
			_dismissButton = GameObject.FindGameObjectWithTag("DismissButton").GetComponent<DismissPopup>();
			_dismissButton.onDismissed += normalize;
		}
		
		_popupPanel.BringIn();
		
		foreach(GameObject GO in GameObject.FindGameObjectsWithTag(tagName))
		{
			StartCoroutine(fadeInMaterial(GO));
		}
		
		StartCoroutine(fadeInBlur());	
	}
	
	IEnumerator fadeInMaterial(GameObject GO)
	{
		Hover hover = GO.GetComponent<Hover>();
		if(hover != null && GO.renderer != null)
		{
			float time = 0f;
			while(time < transitionDuration)
			{
				GO.renderer.material.Lerp(hover.defaultMaterial,hover.hoverMaterial,time);
				time += Time.deltaTime / transitionDuration;
				yield return null;
			}
		}
	}
	
	
	IEnumerator fadeInBlur()
	{
		_blurEffect.enabled = true;
		float time = 0f;
		while(time < transitionDuration)
		{
			_blurEffect.blurSpread = Mathf.Lerp(_blurEffect.blurSpread,blurSpread,time);
			time += Time.deltaTime / transitionDuration;			
			yield return null;
		}
	}
	
	void normalize()
	{
		StopAllCoroutines();
		
		foreach(string tag in _tagsToRevert)
		{
			foreach(GameObject GO in GameObject.FindGameObjectsWithTag(tag))
			{
				Hover hover = GO.GetComponent<Hover>();
				if(hover != null && GO.renderer != null)
				{
					GO.renderer.sharedMaterial = hover.defaultMaterial;
				}
			}
		}
		
		_blurEffect.blurSpread = 0f;
		_blurEffect.enabled = false;
		
		_isTransitioned = false;
	}
}
