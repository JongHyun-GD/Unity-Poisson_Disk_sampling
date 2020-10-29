using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshGenerator))]
public class MeshGeneratorEditor : Editor
{
    bool b_hasMesh = false; // mesh를 생성했는지 검사하는 boolean

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MeshGenerator generator = (MeshGenerator)target;
        if (GUILayout.Button("Generate New Samples"))
        {
            generator.GenerateSampling();
        }

        if (GUILayout.Button("Generate Meshes"))
        {
            if (b_hasMesh) generator.DeleteMesh();

            generator.GenerateMesh();
            b_hasMesh = true;
        }

        if (b_hasMesh && GUILayout.Button("Delete Meshes"))
        {
            b_hasMesh = false;
            generator.DeleteMesh();
        }

        if (generator.noiseTex != null)
        {
            GUI.DrawTexture(new Rect(), generator.noiseTex);
        }
    }
}
