using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshGenerator))]
public class MeshGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MeshGenerator generator = (MeshGenerator)target;
        if (GUILayout.Button("Generate New Samples"))
        {
            generator.GenerateSampling();
        }
    }
}
