using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 盤面全体の管理
/// </summary>
public class Map : MonoBehaviour {

    //各コマのPrefab
    public GameObject oshoPrefab;
    public GameObject hisyaPrefab;

    /// <summary>
    /// 移動候補のマス目に合わせるハイライト
    /// </summary>
    public GameObject HighlightPrefab;

    //盤面のサイズ
    private int columns = 7;
    private int rows = 7;

    /// <summary>
    /// マップ上に存在しているすべての駒
    /// </summary>
    private List<BaseKoma> onBoardKomaList = new List<BaseKoma>();
    /// <summary>
    /// ハイライトのセルのリスト
    /// </summary>
    private List<GameObject> HighlightCellList = new List<GameObject>();

    /// <summary>
    /// 選択中の駒を返す
    /// </summary>
    /// <value>The active unit.</value>
    public BaseKoma FocusingUnit {
        get { return onBoardKomaList.FirstOrDefault(x => x.isSelected); }
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
                    GameObject komaObject = Instantiate(oshoPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
                    BaseKoma baseKoma = komaObject.GetComponent<BaseKoma>();
                    onBoardKomaList.Add(baseKoma);
                }
                else {
                    GameObject komaObject = Instantiate(hisyaPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
                    BaseKoma baseKoma = komaObject.GetComponent<BaseKoma>();
                    onBoardKomaList.Add(baseKoma);
                }
                kirikae = !kirikae;
            }
        }
    }

    public void AddHighlightMovableTile(List<Movable> movableList, GameObject komaGameObject) {
        Vector3 komaPosition = komaGameObject.transform.position;
        foreach (var movable in movableList) {
            if (movable.isAny) {
                Movable SlideMovable = new Movable(0, 0, false);    //何マスでも移動可能な場合の座標保持
                while (true) {
                    SlideMovable.x += movable.x;
                    SlideMovable.y += movable.y;
                    if (!AddHighlightMovableTile(komaPosition, SlideMovable)) {
                        //盤面外の場合はループを辞める
                        break;
                    }
                }
            }
            else {
                AddHighlightMovableTile(komaPosition, movable);
            }
        }
    }

    private bool AddHighlightMovableTile(Vector3 komaPosition, Movable movable) {
        float HighlightPositionX = komaPosition.x + movable.x;
        float HighlightPositionY = komaPosition.y + movable.y;

        //盤面外ならハイライトは表示しない
        if (HighlightPositionX < 0 || HighlightPositionX >= columns ||
            HighlightPositionY < 0 || HighlightPositionY >= rows) {
            return false;
        }
        GameObject highlight = Instantiate(HighlightPrefab, new Vector3(HighlightPositionX, HighlightPositionY, 0.0f), Quaternion.identity);
        HighlightCellList.Add(highlight);
        return true;
    }

    /// <summary>
    /// ハイライトを削除
    /// </summary>
    public void ClearHighlightMovableTile() {
        foreach (var highlight in HighlightCellList) {
            Destroy(highlight);
        }
        HighlightCellList.Clear();
    }

    // Use this for initialization
    void Start () {
        SetupKoma();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
