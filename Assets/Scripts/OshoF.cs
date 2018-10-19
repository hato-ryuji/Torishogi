using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 王将
/// </summary>
public class OshoF: BaseKoma {

    // Use this for initialization
    protected override void Start() {
        base.Start();

    }

    protected override void SetupMovableList() {
        movableList.Add(new Movable(-1, -1, false));
        movableList.Add(new Movable(-1, 0, false));
        movableList.Add(new Movable(-1, 1, false));
        movableList.Add(new Movable(0, -1, false));
        movableList.Add(new Movable(0, 1, false));
        movableList.Add(new Movable(1, -1, false));
        movableList.Add(new Movable(1, 0, false));
        movableList.Add(new Movable(1, 1, false));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
