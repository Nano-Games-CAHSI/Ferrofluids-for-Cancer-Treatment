using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    // Serialized fields for user-assigned GameObjects in the Unity editor
    [SerializeField] private GameObject veins;
    [SerializeField] private GameObject objectToPlace;
    
    private void Start()
    {   
        // Get the mesh filter component of the veins object
        MeshFilter veinsMeshFilter = veins.GetComponent<MeshFilter>();

        if(veinsMeshFilter != null)
        {
            // Get the triangles of the mesh
            int[] triangles = veinsMeshFilter.mesh.triangles;
            
            // Choose a random triangle from the mesh
            int randomTriangleIndex = Random.Range(0, triangles.Length / 3) * 3;

            // Access the vertices of the random triangle
            Vector3 vertexA = veinsMeshFilter.mesh.vertices[triangles[randomTriangleIndex]];
            Vector3 vertexB = veinsMeshFilter.mesh.vertices[triangles[randomTriangleIndex + 1]];
            Vector3 vertexC = veinsMeshFilter.mesh.vertices[triangles[randomTriangleIndex + 2]];

            // Convert the local coordinates of the vertices to world coordinates
            Vector3 worldVertexA = veins.transform.TransformPoint(vertexA);
            Vector3 worldVertexB = veins.transform.TransformPoint(vertexB);
            Vector3 worldVertexC = veins.transform.TransformPoint(vertexC);

            // Randomly interpolate between the three vertices to get a position on the mesh surface
            float u = Random.value;
            float v = Random.value;
            Vector3 randomPosition = BarycentricInterpolation(worldVertexA, worldVertexB, worldVertexC, u, v);

            // Place the object at the random position
            GameObject newObject = Instantiate(objectToPlace, randomPosition, Quaternion.identity);

            // Set a smaller scale value
            Vector3 desiredScale = new Vector3(1f, 1f, 1f);

            // Assign the desired scale to the instantiated object
            newObject.transform.localScale = desiredScale;
        }
        else
        {
            Debug.LogError("No veinsMeshFilter found in the veins object. Please ensure it has a veinsMeshFilter component with a mesh.");
        }
    }

    private Vector3 BarycentricInterpolation(Vector3 A, Vector3 B, Vector3 C, float u, float v)
    {
        if (u + v > 1)
        {
            u = 1 - u;
            v = 1 - v;
        }
        Vector3 pointAB = Vector3.Lerp(A, B, u);
        Vector3 pointAC = Vector3.Lerp(A, C, v);
        return Vector3.Lerp(pointAB, pointAC, v);
    }
}

