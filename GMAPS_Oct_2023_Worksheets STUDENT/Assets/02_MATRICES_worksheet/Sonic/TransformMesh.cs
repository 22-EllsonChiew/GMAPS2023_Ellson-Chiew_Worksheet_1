
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformmatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

       Translate(1, 1);
       Rotate(45);
    }


    void Translate(float x, float y)
    {
        transformmatrix.setIdentity();
        transformmatrix.setTranslationMat(x, y);
        transformmatrix.Print();
        Transform();

        pos = transformmatrix * pos;


    }

    void Rotate(float angle)
    {
         HMatrix2D toOriginMatrix = new HMatrix2D();
         HMatrix2D fromOriginMatrix = new HMatrix2D();
         HMatrix2D rotateMatrix = new HMatrix2D();

         toOriginMatrix.setTranslationMat(-pos.x, -pos.y);

         fromOriginMatrix.setTranslationMat(pos.x, pos.y);


         rotateMatrix.setRotationMat(angle);

         transformmatrix.setIdentity();
         transformmatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

         Transform();

        /*float cosAngle = Mathf.Cos(angle * Mathf.Deg2Rad);
        float sinAngle = Mathf.Sin(angle * Mathf.Deg2Rad);

        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x - pos.x;
            float y = vertices[i].y - pos.y;

            vertices[i].x = cosAngle * x - sinAngle * y + pos.x;
            vertices[i].y = sinAngle * x + cosAngle * y + pos.y;
        }

        meshManager.clonedMesh.vertices = vertices;*/
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            //Debug.Log(vert.x + " Before ");
            vert = transformmatrix * vert;

            
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;

            //Debug.Log(vert.x + " After ");
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
