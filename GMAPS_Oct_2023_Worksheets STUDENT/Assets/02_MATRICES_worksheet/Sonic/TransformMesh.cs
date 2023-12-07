
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
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); //create pos variable and use HVector2D, and use x and y values to target gameobject position

       Translate(1, 1); //translate the gameobject mesh to 1 , 1 coordinates
       Rotate(45); // rotate the gameobject mesh to 45 degree, can change the value if the angle 
    }


    void Translate(float x, float y)
    {
        //use transformMatrix that is used as HMatrix and use method setIdentity 
        transformmatrix.setIdentity();
        transformmatrix.setTranslationMat(x, y); //set translation maxtrix to x and y values 
        transformmatrix.Print();
        Transform();

        pos = transformmatrix * pos; //multiply the transfomMatrix with the pos that was used in void Start


    }

    void Rotate(float angle)
    {
        // create instance for toOriginMatrix, fromOriginMatrix and rotateMatrix and initizlied it
         HMatrix2D toOriginMatrix = new HMatrix2D();
         HMatrix2D fromOriginMatrix = new HMatrix2D();
         HMatrix2D rotateMatrix = new HMatrix2D();

        // use toOriginMatrix and then calles the method setTranslation matrix and set the value of negative x and y so it will translate to the coordinates 
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);

        // use fromOriginMatrix and then calles the method setTranslation matrix and set the value of x and y so it will translate to the coordinates 
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        //use rotateMatrix instance and then calls the rotation matrix method and set it with specific angle later when calling it
         rotateMatrix.setRotationMat(angle);

         transformmatrix.setIdentity();
         transformmatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; //multiply the matrices toOriginMatrix, fromOriginMatrix and rotateMatrix into single composite 

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
        vertices = meshManager.clonedMesh.vertices; // bring the clonedmesh from meshmanager scriot and called it vertices variables

        //start a for loop with the i variable and iterates vertices with the length
        for (int i = 0; i < vertices.Length; i++)
        {
            //create new HVector2D which is vert, and set the x and y coordinates of the vertices
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            //Debug.Log(vert.x + " Before ");
            vert = transformmatrix * vert; //calculaye the vert by multiplying transformMatrix and apply it to trasnformation vector to vert

            //update x and y coordinates
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;

            //Debug.Log(vert.x + " After ");
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
