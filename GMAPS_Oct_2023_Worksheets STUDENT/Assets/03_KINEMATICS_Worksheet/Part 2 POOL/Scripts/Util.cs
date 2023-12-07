using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2) //add two parameters of HVector2D of p1 and p2 and returnss it as float 
    {
        float posX = p2.x - p1.x; //create posX and both p1 and p2 with the x axis coordinates 
        float posY = p2.y - p1.y;  //create posX and both p1 and p2 with the y axis coordinates 
        return Mathf.Sqrt(posX * posX + posY * posY); //using Euclidean distance to calculate between both position of the value
    }
}

