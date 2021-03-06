﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DefaultClosePageAnim))]
[RequireComponent(typeof(DefaultOpenPageAnim))]
public abstract class Page_Base : MonoBehaviour {
	[HideInInspector]public bool isClosing = false;
	[HideInInspector]public bool isOpening = false;
	private DefaultOpenPageAnim openPageAnim;
	private DefaultClosePageAnim closePageAnim;
	private GameObject maskObj;

	/// <summary>
	///  返回上一頁
	/// </summary>
	public void OnBackPageBtn(){
		PageManerger.BackPage ();
	}



	/// <summary>
	/// 關閉該頁面
	/// 由PageManerger呼叫
	/// </summary>
	public void Close(){
		StartCoroutine (IE_Close());
	}

	IEnumerator IE_Close(){
		if (maskObj == null) {
			CreateMaskObj ();
		}

		maskObj.SetActive (true);
		isClosing = true;
		OnClose ();
		yield return StartCoroutine (IE_ClosePageAnim ());
		isClosing = false;
		maskObj.SetActive (false);
	}

	private void CreateMaskObj(){
		maskObj = new GameObject ();
		maskObj.name = "Mask";
		Image _image = maskObj.AddComponent<Image> ();
		_image.color = new Color (0, 0, 0, 0);
		_image.rectTransform.sizeDelta = this.transform.parent.GetComponent<RectTransform> ().sizeDelta;
		maskObj.transform.SetParent (this.transform);
		maskObj.transform.SetSiblingIndex (this.transform.childCount - 1);
	}
	/// <summary>
	/// 當關閉頁面觸發
	/// 給繼承複寫用
	/// </summary>
	protected abstract void OnClose();

	/// <summary>
	/// 關閉頁面動畫
	/// 如需變化從新頁面複寫
	/// </summary>
	protected virtual IEnumerator IE_ClosePageAnim(){
		if (closePageAnim == null) {
			closePageAnim = this.GetComponent<DefaultClosePageAnim> ();
		}

		closePageAnim.Play ();
		yield return new WaitForSeconds (closePageAnim.duration);
	}






	/// <summary>
	/// 開啟該頁面
	/// 由PageManerger呼叫
	/// </summary>
	public void Open(){
		StartCoroutine (IE_Open ());
	}

	IEnumerator IE_Open(){
		if (maskObj == null) {
			CreateMaskObj ();
		}

		maskObj.SetActive (true);
		isOpening = false;
		OnOpen ();
		yield return StartCoroutine (IE_OpenPageAnim ());
		isOpening = true;
		maskObj.SetActive (false);
	}

	/// <summary>
	/// 當開啟頁面觸發
	/// 給繼承複寫用
	/// </summary>
	protected abstract void OnOpen();

	/// <summary>
	///  開啟頁面動畫
	/// 如需變化從新頁面複寫
	/// </summary>
	protected virtual IEnumerator IE_OpenPageAnim(){
		if (openPageAnim == null) {
			openPageAnim = this.GetComponent<DefaultOpenPageAnim> ();
		}

		openPageAnim.Play ();
		yield return new WaitForSeconds (openPageAnim.duration);
	}
}
