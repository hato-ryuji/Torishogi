using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 飛車
/// </summary>
public class HisyaF : BaseKoma {

    // Use this for initialization
    protected override void Start() {
        team = TeamEnum.friend;
        base.Start();
    }

    protected override void SetupMovableList() {
        movableList.Add(new Movable(-1, 0, true));
        movableList.Add(new Movable(0, -1, true));
        movableList.Add(new Movable(0, 1, true));
        movableList.Add(new Movable(1, 0, true));
    }

    // Update is called once per frame
    void Update() {

    }
}
