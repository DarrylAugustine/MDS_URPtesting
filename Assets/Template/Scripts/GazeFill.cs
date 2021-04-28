using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Headjack;
public class GazeFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public ProjectInstance projectInstance;
	private bool highlight=false;
	public RawImage rawImage;
	public float fill;
	private Material mat;
	private void Awake()
	{
		mat = rawImage.material = new Material( rawImage.material);
	}
	void OnEnable()
	{
		highlight = false;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		highlight = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		highlight = false;
	}
	void Update ()
	{
		bool isHighlighted = highlight;
		// if this menu item is hidden behind the menu mask, disable gaze control
		// NOTE: the comparison values are "magic" values that correspond with the menu mask edges at time of writing
		if (rawImage.rectTransform.position.y > 1.8f || rawImage.rectTransform.position.y < 0.8f) {
			isHighlighted = false;
		}

		fill =Mathf.Clamp01( fill + Time.deltaTime*(isHighlighted ? 0.5f : -4f));
		mat.SetFloat("_Fill", fill);
		if (fill == 1)
		{
			fill = 0;
			App.Fade(true, 1f, delegate (bool s, string e)
			{
				VideoPlayerManager.Instance.Initialize(projectInstance.id, false, delegate (bool ss, string ee)
				{
					//
				}, true);
			});
			gameObject.SetActive(false);
		}
	}
}
