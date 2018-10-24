using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlight : MonoBehaviour , IPointerClickHandler {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// オブジェクトをクリックした際の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }
}
