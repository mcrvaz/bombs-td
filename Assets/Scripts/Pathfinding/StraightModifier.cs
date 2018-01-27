using System;
using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

public class StraightModifier : MonoModifier {

    private Vector3 initialPosition;

    void Start() {
        initialPosition = transform.position;
    }

    public override int Order { get { return 60; } }

    private float RoundToHalf(float v) {
        const float half = 0.5f;
        float decimalPart = (float) Math.Truncate(v);
        if(decimalPart == 0) return decimalPart;
        return decimalPart > 0 ? (decimalPart + half):(decimalPart - half);
    }

    private Vector3 AdjustNode(Vector3 node) {
        if(Math.Abs(node.x) > Math.Abs(node.y)) {
            return new Vector3(RoundToHalf(node.x), transform.position.y, 0);
        }
        return new Vector3(transform.position.x, RoundToHalf(node.y), 0);
    }

    public override void Apply (Path p) {
        if (p.error || p.vectorPath == null) return;
        var newPath = new List<Vector3>(p.vectorPath.Count);
        foreach (var node in p.vectorPath) {
            var path = AdjustNode(node);
            print(path);
            newPath.Add(path);
        }
        p.vectorPath = newPath;
    }
}