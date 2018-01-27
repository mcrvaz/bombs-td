using System;
using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

public class StraightModifier : MonoModifier {

    public override int Order { get { return 60; } }

    private float RoundToHalf(float v) {
        const float half = 0.5f;
        float integerPart = (float) Math.Truncate(v);
        return integerPart > 0 ? (integerPart + half):(integerPart - half);
    }

    private Vector3 AdjustNode(Vector3 node) {
        return new Vector3(RoundToHalf(node.x), RoundToHalf(node.y), 0);
    }

    public override void Apply (Path p) {
        if (p.error || p.vectorPath == null) return;
        var newPath = Pathfinding.Util.ListPool<Vector3>.Claim(p.vectorPath.Count);
        foreach (var node in p.vectorPath) {
            newPath.Add(AdjustNode(node));
        }
        p.vectorPath = newPath;
    }
}