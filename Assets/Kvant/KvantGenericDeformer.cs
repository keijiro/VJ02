// Generic Mesh Deformer
// By Keijiro Takahashi, 2014

using UnityEngine;
using System.Collections;

public class KvantGenericDeformer : MonoBehaviour
{
    // Public properties.
    public bool smooth = true;
    public bool surfaceSpace = false;
    public int octave = 3;

    [SerializeField] float _displacement = 1;
    [SerializeField] float _noiseScale = 1;
    [SerializeField] float _noiseSpeed = 0.2f;

    public float displacement { get { return _displacement; } set { _displacement = value; } }
    public float noiseScale   { get { return _noiseScale;   } set { _noiseScale   = value; } }
    public float noiseSpeed   { get { return _noiseSpeed;   } set { _noiseSpeed   = value; } }

    // Main mesh object.
    Mesh mesh;

    // Source mesh information.
    int[] index;
    Vector3[] position;
    Vector3[] vector1;  // normal
    Vector3[] vector2;  // tangent
    Vector3[] vector3;  // binormal

    // Temporary vertex arrays.
    Vector3[] temp1;
    Vector3[] temp2;

    // Noise parameters.
    Vector3 noiseOffset1 = Vector3.right;
    Vector3 noiseOffset2 = Vector3.up;
    Vector3 noiseOffset3 = Vector3.forward;

    void Awake ()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var source = meshFilter.sharedMesh;

        // Copy the basic information.
        index = source.GetIndices(0);
        position = source.vertices;
        vector1 = source.normals;

        if (surfaceSpace)
        {
            // Copy the tangent vectors (with removing the w component) and make binormal vectors.
            vector2 = new Vector3[position.Length];
            vector3 = new Vector3[position.Length];

            var tangents = source.tangents;
            for (var i = 0; i < position.Length; i++)
            {
                vector2[i] = (Vector3)tangents[i];
                vector3[i] = Vector3.Cross(vector1[i], vector2[i]) * tangents[i].w;
            }
        }

        // Make a new mesh.
        mesh = new Mesh();
        mesh.MarkDynamic();

        if (smooth)
        {
            // Smooth shading: the mash has same number of vertices.
            temp1 = new Vector3[position.Length];
            mesh.vertices = temp1;

            // Simply copy the UVs and the tangent vectors.
            mesh.uv = source.uv;
            mesh.uv2 = source.uv2;
            mesh.tangents = source.tangents;

            // Simply copy the indices.
            mesh.SetIndices(index, MeshTopology.Triangles, 0);
        }
        else
        {
            // Flat shading: split the vertices for each triangle.
            temp1 = new Vector3[position.Length];
            temp2 = new Vector3[index.Length];
            mesh.vertices = temp2;

            // Make uv array for the split triangles.
            var sourceUv = source.uv;
            if (sourceUv != null && sourceUv.Length > 0)
            {
                var uv = new Vector2[index.Length];
                for (var i = 0; i < index.Length; i++)
                    uv[i] = sourceUv[index[i]];
                mesh.uv = uv;
            }

            // Make 2nd-uv array for the split triangles.
            var sourceUv2 = source.uv2;
            if (sourceUv2 != null && sourceUv2.Length > 0)
            {
                var uv2 = new Vector2[index.Length];
                for (var i = 0; i < index.Length; i++)
                    uv2[i] = sourceUv2[index[i]];
                mesh.uv2 = uv2;
            }

            // Make tangent tangent vector array for the split triangles.
            var sourceTangents = source.tangents;
            if (sourceTangents != null && sourceTangents.Length > 0)
            {
                var tangents = new Vector4[index.Length];
                for (var i = 0; i < index.Length; i++)
                    tangents[i] = sourceTangents[index[i]];
                mesh.tangents = tangents;
            }

            // Make an index array for the split triangles.
            var index2 = new int[index.Length];
            for (var i = 0; i < index.Length; i++)
                index2[i] = i;

            mesh.SetIndices(index2, MeshTopology.Triangles, 0);
        }

        // Set the new mesh to the renderer.
        meshFilter.sharedMesh = mesh;
    }

    void Update ()
    {
        // Move the offset vectors.
        var delta = Time.deltaTime * _noiseSpeed;

        noiseOffset1 += Vector3.right   * delta;
        noiseOffset2 += Vector3.up      * delta;
        noiseOffset3 += Vector3.forward * delta;

        // Move the vertices.
        if (surfaceSpace)
        {
            for (var i = 0; i < position.Length; i++)
            {
                var v = position[i];
                var c1 = (v + noiseOffset1) * _noiseScale;
                var c2 = (v + noiseOffset2) * _noiseScale;
                var c3 = (v + noiseOffset3) * _noiseScale;
                v += vector1[i] * (Kvant.Fractal(c1, octave) * _displacement);
                v += vector2[i] * (Kvant.Fractal(c2, octave) * _displacement);
                v += vector3[i] * (Kvant.Fractal(c3, octave) * _displacement);
                temp1[i] = v;
            }
        }
        else
        {
            for (var i = 0; i < position.Length; i++)
            {
                var v = position[i];
                var c1 = (v + noiseOffset1) * _noiseScale;
                var c2 = (v + noiseOffset2) * _noiseScale;
                var c3 = (v + noiseOffset3) * _noiseScale;
                v += Vector3.right   * (Kvant.Fractal(c1, octave) * _displacement);
                v += Vector3.up      * (Kvant.Fractal(c2, octave) * _displacement);
                v += Vector3.forward * (Kvant.Fractal(c3, octave) * _displacement);
                temp1[i] = v;
            }
        }

        if (smooth)
        {
            // Simply copy the moved vertices.
            mesh.vertices = temp1;
        }
        else
        {
            // Split the moved vertices.
            for (var i = 0; i < index.Length; i++)
                temp2[i] = temp1[index[i]];
            mesh.vertices = temp2;
        }

        // Rebuild the mesh.
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
