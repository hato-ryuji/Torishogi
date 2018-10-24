using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 駒のスクリプトのベースクラス
/// </summary>
public abstract class BaseKoma : MonoBehaviour, IPointerClickHandler {
    protected SpriteRenderer spriteRenderer;
    public bool isSelected = false;
    protected List<Movable> movableList = new List<Movable>();

    public TeamEnum team;

    protected GameManager gameManager;
    protected Map map;

    public float x {
        get { return GetComponent<Transform>().position.x;}
    }

    public float y {
        get { return GetComponent<Transform>().position.y; }
    }

    // Use this for initialization
    protected virtual void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetupMovableList();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        map = GameObject.Find("GameManager").GetComponent<Map>();
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

        Debug.Log(map.FocusingUnit);
        Debug.Log(this);

        if (map.FocusingUnit == null) {
            Debug.Log("A");
            Focusing();
            map.AddHighlightMovableTile(movableList, gameObject);
        }
        else if (map.FocusingUnit ==　this) {
            Debug.Log("B");
            Unfocusing();
            map.ClearHighlightMovableTile();
        }
        else if(map.FocusingUnit != this) {
            Debug.Log("C");
            //map.FocusingUnitに対してフォーカス取り消し処理
            map.FocusingUnit.Unfocusing();
            map.ClearHighlightMovableTile();
            Focusing();
            map.AddHighlightMovableTile(movableList, gameObject);
        }
    }

    /// <summary>
    /// この駒が選択状態になった
    /// </summary>
    protected void Focusing() {
        isSelected = true;
        Color color = spriteRenderer.color;
        color.a = 0.7f;
        spriteRenderer.color = color;
    }

    /// <summary>
    /// この駒が非選択状態になった
    /// </summary>
    protected void Unfocusing() {
        isSelected = false;
        Color color = spriteRenderer.color;
        color.a = 1.0f;
        spriteRenderer.color = color;
    }

    /// <summary>
    /// 駒の座標を移動する
    /// </summary>
    /// <param name="destination">移動先の座標</param>
    public void Move(Vector3 destination) {
        gameObject.transform.position = destination;
    }
}
