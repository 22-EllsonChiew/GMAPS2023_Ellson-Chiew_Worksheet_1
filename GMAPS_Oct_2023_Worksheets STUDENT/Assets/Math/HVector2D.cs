using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

     public static HVector2D operator +(HVector2D a, HVector2D b)
     {
        return new HVector2D(a.x + b.x, a.y + b.y);
     }

     public static HVector2D operator -(HVector2D a, HVector2D b)
     {
        return new HVector2D(a.x - b.x, a.y - b.y);
     }

     public static HVector2D operator *(HVector2D a, float scalar)
     {
        return new HVector2D(a.x * scalar, a.y * scalar);
     }

     public static HVector2D operator /(HVector2D a, float scalar)
     {
        return a * (1 / scalar);
     }

    public float Magnitude()
    {
        return (float)Mathf.Sqrt(x * x + y * y);

    }

     public void Normalize()
     {
        float mag = Magnitude();
        x /= mag;
        y /= mag;
     }

     public float DotProduct(HVector2D other)
     {
        return (x * other.x + y * other.y);
     }

     public HVector2D Projection(HVector2D other)
     {
        /*float dot = DotProduct(other);
        float vec = other.Magnitude() * other.Magnitude();
        float scalar = dot / vec;
        return other * scalar;*/

        float dot = this.DotProduct(other);
        float vecMag = other.Magnitude();
        float proj = dot / other.DotProduct(other);
        return other * proj;
        //float scalar = dot / (vecMag * vecMag);     
        //return other * scalar;
     }

     public float FindAngle(HVector2D other)
     {
        
        float angle = Mathf.Acos(DotProduct(other) / (Magnitude() * other.Magnitude())); 
        
        //if x less then 0 it makes the angle on the right side and make it negative on the correct side
        if(x < 0)
        {
            angle = -angle;
        }
        return angle;
     }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y); 
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, h); 
    }

    // public void Print()
    // {

    // }
}
