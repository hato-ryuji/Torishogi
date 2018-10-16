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

    //移動候補のマス目に合わせるハイライト
    public GameObject HighlightPrefab;

    // Use this for initialization
    void Start () {
        SetupKoma();
        Instantiate(HighlightPrefab, new Vector3(1, 1, 0.0f), Quaternion.identity);
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

    public void HighlightMovableTile(List<Movable> movableList, GameObject komaGameObject) {
        Vector3 komaPosition = komaGameObject.transform.position;
        foreach (var movable in movableList) {
            if (movable.isAny) {
                Movable SlideMovable = new Movable(0, 0, false);    //何マスでも移動可能な場合の座標保持
                while (true) {
                    SlideMovable.x += movable.x;
                    SlideMovable.y += movable.y;
                    if (!HighlightMovableTile(komaPosition, SlideMovable)) {
                        //盤面外の場合はループを辞める
                        break;
                    }
                }
            }
            else {
                HighlightMovableTile(komaPosition, movable);
            }
        }
    }

    private bool HighlightMovableTile(Vector3 komaPosition, Movable movable) {
        float HighlightPositionX = komaPosition.x + movable.x;
        float HighlightPositionY = komaPosition.y + movable.y;

        //盤面外ならハイライトは表示しない
        if (HighlightPositionX < 0 || HighlightPositionX >= columns ||
            HighlightPositionY < 0 || HighlightPositionY >= rows) {
            return false;
        }
        Instantiate(HighlightPrefab, new Vector3(HighlightPositionX, HighlightPositionY, 0.0f), Quaternion.identity);
        return true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
