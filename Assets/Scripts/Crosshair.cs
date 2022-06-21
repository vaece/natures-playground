using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public LayerMask targetMask;
    public SpriteRenderer dot;
    public Color dotHightlightColor;
    Color originalDotColor;

    Transform player;

    void Start() {
        Cursor.visible = false;
        originalDotColor = dot.color;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (player == null) {
            Cursor.visible = true;
        }
    }

    public void DetectTargets(Ray ray) {
        if (Physics.Raycast(ray, 100, targetMask)) {
            dot.color = dotHightlightColor;
        }
        else {
            dot.color = originalDotColor;
        }
    }

}
