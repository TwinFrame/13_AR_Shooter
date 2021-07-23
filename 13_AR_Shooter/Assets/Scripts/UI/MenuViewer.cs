using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class MenuViewer : MonoBehaviour
{
	private CanvasGroup _canvasGroup;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void Open()
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
	}

	public void Close()
	{
		_canvasGroup.alpha = 0f;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}
}
