﻿using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 w = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<NavMeshAgent2D>().destination = w;
        }
    }
}