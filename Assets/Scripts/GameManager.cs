using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //盤面のサイズ
    private int columns = 7;
    private int rows = 7;

    //各コマのPrefab
    public GameObject oshoPrefab;
    public GameObject hisyaPrefab;

	// Use this for initialization
	void Start () {
        SetupKoma();
	}

    /// <summary>
    /// 駒の初期設定の処理を記載する予定。
    /// ・今は交互に駒を並べているだけ
    /// </summary>
    private void SetupKoma() {
        bool kirikae = true;
        for (int x = 0; x < columns; x++) {
            for (int y = 0; y < rows; y++) {
                if (kirikae) {
                    Instantiate(oshoPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
                }
                else {
                    Instantiate(hisyaPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
                }
                kirikae = !kirikae;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
