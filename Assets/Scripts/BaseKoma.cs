using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 駒のスクリプトのベースクラス
/// </summary>
public abstract class BaseKoma : MonoBehaviour, IPointerClickHandler{
    protected SpriteRenderer spriteRenderer;

    // Use this for initialization
    protected virtual void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerClick(PointerEventData eventData) {
        Debug.Log("OnPointerClick オブジェクトのクリックを検知");
        Color color = spriteRenderer.color;
        color.a = 0.7f;
        spriteRenderer.color = color;
    }
}
