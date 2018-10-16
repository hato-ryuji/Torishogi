using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 駒のスクリプトのベースクラス
/// </summary>
public abstract class BaseKoma : MonoBehaviour, IPointerClickHandler{
    protected SpriteRenderer spriteRenderer;
    protected bool isSelected = false;
    protected List<Movable> movableList = new List<Movable>();

    protected GameManager gameManager;

    // Use this for initialization
    protected virtual void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetupMovableList();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected abstract void SetupMovableList();

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// オブジェクトをクリックした際の処理
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerClick(PointerEventData eventData) {
        Debug.Log("OnPointerClick オブジェクトのクリックを検知");
        isSelected = !isSelected;
        Color color = spriteRenderer.color;
        color.a = isSelected ? 0.7f : 1.0f;
        spriteRenderer.color = color;

        gameManager.HighlightMovableTile(movableList, gameObject);
    }
}
