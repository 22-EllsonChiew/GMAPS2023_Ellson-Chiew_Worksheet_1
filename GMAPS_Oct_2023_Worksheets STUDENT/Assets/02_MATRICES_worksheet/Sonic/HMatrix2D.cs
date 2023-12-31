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
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Columns; x++)
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

        //loop over the left.rows of the maxtrix then loop variabe i 
        for (int i = 0; i < left.Rows; i++)
        {
            // loop over the left.columns of the maxtrix then loop variabe j
            for (int j = 0; j < left.Columns; j++)
            {
                //add elements from the two matrix and store them in the result Matrix while using minus operator corresponding to rows and columns indices from left and right entriess 
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
                //add elements and uses left matrix entires and the varables values and minus the scalar value 
                resultMatrix[i, j] = left.entries[i, j] - scalar;
            }
        }

        return new HMatrix2D(resultMatrix);
    }

    // Note that the second argument is a HVector2D object
    
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {

        return new HVector2D
        (
            //calculaes the x axis of the HMatrix2D and add the left element of the entires and multiply the right y axis and add left entires element multiple by right.h which is the y axis with 0 value back in HVector2D
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h

        );
    
     }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
   {
       return new HMatrix2D
       (

       //use matrix multiplication, each element of the resulting matrix is the calculated by using dot product corresponding row from left matrix and column to right matrix and repeat the same for all 
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

    


    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {

        // Compare the elements of the matrices at each position
        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                //compares left entires and right entires element by element 
                if (left.entries[i, j] == right.entries[i, j])
                {
                    return true;
                }
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // Compare the elements of the matrices at each position
        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                //compares left entires and right entires element by element 
                if (left.entries[i, j] != right.entries[i, j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        HMatrix2D other = (HMatrix2D)obj;

        // Compare the elements of the matrices at each position
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (entries[i, j] != other.entries[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            // Use prime numbers to combine hash codes of individual elements
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    hash = hash * 31 + entries[i, j].GetHashCode();
                }
            }

            return hash;
        }
    }

    /*public HMatrix2D transpose()
    {
       // return // your code here
    }

    public float getDeterminant()
    {
        //return // your code here
    }*/

    public void setIdentity()
     {
         for(int y = 0; y < Rows; y++)
         {
             for(int x = 0; x < Columns; x++)
             {
                //compare the x values and y value
                 if(x == y)
                 {
                     entries[x, y] = 1; //if it is diagonal of the matrix set the matrix point into x and y to 1
                }
                 else
                 {
                    entries[x, y] = 0; // else set to 0
                 }
             }
         }
     }

     public void setTranslationMat(float transX, float transY)
     {
        setIdentity();
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

     public void setRotationMat(float rotDeg)
     {
        setIdentity();// call method of the setIdentity 
        //calculate the radiant, and equals to rotation angle multiply by mathf deg3raad as it converts to degrees
        float rad = rotDeg * Mathf.Deg2Rad;

        
        entries[0, 0] = Mathf.Cos(rad);//set matrix position and cosin to the angle of radiant
        entries[0, 1] = -Mathf.Sin(rad); //set matrix position and negative sine to the angle of radiant
        entries[1, 0] = Mathf.Sin(rad); //set matrix position and  sine to the angle of radiant
        entries[1, 1] = Mathf.Cos(rad); //set matrix position and cosin to the angle of radiant
    }

     /*public void setScalingMat(float scaleX, float scaleY)
     {
         // your code here
     }*/

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


