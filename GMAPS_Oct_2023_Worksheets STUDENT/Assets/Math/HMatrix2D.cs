using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D : MonoBehaviour
{
    
    public float[,] entries { get; set; } = new float[3, 3];

    public int Rows => entries.GetLength(0);
    public int Columns => entries.GetLength(1);

    public HMatrix2D()
    {
        entries = new float[3, 3];
    }

        

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[x, y] = multiArray[x, y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                float m10, float m11, float m12,
                float m20, float m21, float m22)
    {
        // First row
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //check if input matrix are null
        if (left == null || right == null)
        {
            //throw new ArgumentNullException("Matrices must not be null");
        }

        //check if both left and right matrix have the same dimensions
        if (left.Rows != right.Rows || left.Columns != right.Columns)
        {
            //throw new ArgumentException("Both matrices must have the same dimensions");
        }

        //new matrix to store the rsult
        float[,] resultMatrix = new float[left.Rows, left.Columns];

        //loop each element in the matrix
        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                //add elements from the two matrix and store them in the result Matrix
                resultMatrix[i, j] = left.entries[i, j] + right.entries[i, j];
            }
        }

        return new HMatrix2D(resultMatrix);
    }
    



    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {

        float[,] resultMatrix = new float[left.Rows, left.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                //add elements from the two matrix and store them in the result Matrix
                resultMatrix[i, j] = left.entries[i, j] - right.entries[i, j];
            }
        }

        return new HMatrix2D(resultMatrix);
    }

    

     public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        float[,] resultMatrix = new float[left.Rows, left.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                //add elements from the two matrix and store them in the result Matrix
                resultMatrix[i, j] = left.entries[i, j] - scalar;
            }
        }

        return new HMatrix2D(resultMatrix);
    }

    // Note that the second argument is a HVector2D object
    
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {

        return new HVector2D
        {
            x = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y,
         y = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y
        };



    
     }

    // Note that the second argument is a HMatrix2D object
    //
     public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (

        left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
        left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
        left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

        left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
        left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
        left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

        left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
        left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
        left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
        );
    }

    /* public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // your code here
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // your code here
    }

    public override bool Equals(object obj)
    {
        // your code here
    }

    public override int GetHashCode()
    {
        // your code here
    }

    public HMatrix2D transpose()
    {
        return // your code here
    }

    public float getDeterminant()
    {
        return // your code here
    }*/

    public void setIdentity()
     {
         for(int y = 0; y < 3; y++)
         {
             for(int x = 0; x < 3; x++)
             {
                 if(x == y)
                 {
                     entries[y, x] = 1; // put a , for two dimensional array
                 }
                 else
                 {
                    entries[y, x] = 0;
                 }
             }
         }
     }

     public void setTranslationMat(float transX, float transY)
     {
         // your code here
     }

     public void setRotationMat(float rotDeg)
     {
         // your code here
     }

     public void setScalingMat(float scaleX, float scaleY)
     {
         // your code here
     }

     public void Print()
     {
         string result = "";
         for (int r = 0; r < 3; r++)
         {
             for (int c = 0; c < 3; c++)
             {
                 result += entries[r, c] + "  ";
             }
             result += "\n";
         }
         Debug.Log(result);
     }
 }


