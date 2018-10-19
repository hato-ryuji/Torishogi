using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 盤面全体の管理
/// </summary>
public class Map : MonoBehaviour {

    /// <summary>
    /// マップ上に存在しているすべての駒
    /// </summary>
    private List<BaseKoma> onBoardKomaList;

    /// <summary>
    /// 選択中の駒を返す
    /// </summary>
    /// <value>The active unit.</value>
    public BaseKoma FocusingUnit {
        get { return onBoardKomaList.First(x => x.isSelected); }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
