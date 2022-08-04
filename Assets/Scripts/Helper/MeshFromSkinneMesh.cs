using UnityEngine;

[ExecuteInEditMode]
public class MeshFromSkinneMesh : MonoBehaviour
{
    void Start()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
            meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
            DestroyImmediate(skinnedMeshRenderer);
            DestroyImmediate(this);
        }
    }
}
