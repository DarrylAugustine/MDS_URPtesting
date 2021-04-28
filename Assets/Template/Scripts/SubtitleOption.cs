using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SubtitleOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
	public Text text;
	public int index;
	public MainVideoControls mainVideoControls;
	public VideoControls videoControls;
	public GameObject currentSubtitleCheck;
	public RawImage block;

	public void Initialize(int index, string text)
	{
		this.index = index;
		this.text.text = text;
	}

	void OnEnable() {
		// new gameobjects should be incorporated in vertical layout group
		Canvas.ForceUpdateCanvases();
	}

	public void OnClick()
	{
		Debug.Log("Loading subtitle " + index);
		mainVideoControls.subtitlesIndex = index;
		videoControls.currentMenu = VideoControls.Menu.Main;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		block.color = videoControls.blockHighlight;
		text.color = videoControls.graphicHighlight;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		block.color = videoControls.blockNormal;
		text.color = videoControls.graphicNormal;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		block.color = videoControls.blockPressed;
		text.color = videoControls.graphicPressed;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (text.color == videoControls.graphicPressed)
		{
			block.color = videoControls.blockHighlight;
			text.color = videoControls.graphicHighlight;
		} else {
			block.color = videoControls.blockNormal;
			text.color = videoControls.graphicNormal;
		}
	}

	void OnDisable() {
		block.color = videoControls.blockNormal;
		text.color = videoControls.graphicNormal;
	}
}
