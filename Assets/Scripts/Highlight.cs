using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour , IPointerClickHandler {
    private Map map;

    // Use this for initialization
    void Start () {
        map = GameObject.Find("GameManager").GetComponent<Map>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// オブジェクトをクリックした際の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData) {
        map.MoveHighlightPosirion(gameObject);
    }
}
