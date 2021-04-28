using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopupMessage : MonoBehaviour
{
	public static PopupMessage instance;
	public GameObject buttonConfirm, buttonLeft, buttonRight;
	public delegate void Callback(bool playerConfirmed);
	public Animator canvasAnimator;
	private bool waitForConfirm, waitForYes, waitForNo;
	public TextMeshProUGUI messageText;
	public enum ButtonMode
	{
		None = 0,
		Confirm = 1,
		YesNo = 2
	}
	void Awake()
	{
		instance = this;
	}
	public void Confirm()
	{
		waitForConfirm = false;
	}
	public void Yes()
	{
		waitForYes = false;
	}
	public void No()
	{
		waitForNo = false;
	}
	public void Show(string message, ButtonMode buttonMode, Callback callback)
	{
		Debug.Log("Showing message 1");
		canvasAnimator.SetBool("ShowMessage", true);
		gameObject.SetActive(true);
		buttonConfirm.SetActive(buttonMode == ButtonMode.Confirm);
		buttonLeft.SetActive(buttonMode == ButtonMode.YesNo);
		buttonRight.SetActive(buttonMode == ButtonMode.YesNo);
		messageText.text = message;
		StartCoroutine(ShowMessage(message, buttonMode, callback));
	}
	private IEnumerator ShowMessage(string message, ButtonMode buttonMode, Callback callback)
	{
		yield return null;
		Debug.Log("Showing message 2");
		if (buttonMode == ButtonMode.Confirm)
		{
			waitForConfirm = true;
			while (waitForConfirm) yield return null;
			callback?.Invoke(true);
		}
		else if (buttonMode == ButtonMode.YesNo)
		{
			waitForYes = waitForNo = true;
			while (waitForYes && waitForNo) yield return null;
			if (!waitForYes) callback?.Invoke(true);
			if (!waitForNo) callback?.Invoke(false);
		}
		else
		{
			while (true) yield return null;
		}
		waitForConfirm = waitForYes = waitForNo = false;
		canvasAnimator.SetBool("ShowMessage", false);
		Debug.Log("Finished message");
	}
}
