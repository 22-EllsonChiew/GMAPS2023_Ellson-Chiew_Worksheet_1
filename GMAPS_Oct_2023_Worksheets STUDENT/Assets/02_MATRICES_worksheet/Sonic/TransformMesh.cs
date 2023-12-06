
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformmatrix = new HMatrix2D();
    HMatrix2D ToOriginMatrix = new HMatrix2D();
    HMatrix2D FromOriginMatrix = new HMatrix2D();
    HMatrix2D rotatematrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1, 1);
    }


    void Translate(float x, float y)
    {
        transformmatrix.setIdentity();
        transformmatrix.setTranslationMat(x, y);
        transformmatrix.Print();
        Transform();

        pos = transformmatrix * pos;
        

    }

    /*void Rotate(float angle)
    {
        transformmatrix.setIdentity();

        // your code here

       // transformmatrix = FromOriginMatrix * // your code here;

        Transform();
    }*/

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            Debug.Log(vert.x + " Before ");
            vert = transformmatrix * vert;

            
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;

            Debug.Log(vert.x + " After ");
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
