using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
     public HVector2D Position = new HVector2D(0, 0);
     public HVector2D Velocity = new HVector2D(0, 0);
    
     [HideInInspector]
     public float Radius;

     private void Start()
    {
         Position.x = transform.position.x;
         Position.y = transform.position.y;

         Sprite sprite = GetComponent<SpriteRenderer>().sprite;
         Vector2 sprite_size = sprite.rect.size;
         Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
         Radius = local_sprite_size.x / 2f;
     }

     public bool IsCollidingWith(float x, float y)
     {
         float distance = Util.FindDistance(Position, new HVector2D(x, y)); // to find the distance called util script and called the method find distance of the position of x and y axis 
         return distance <= Radius;
     }

     public bool IsCollidingWith(Ball2D other)
     {
        float distance = Util.FindDistance(Position, other.Position); //to find the distance called util script and called the method find distance with other ball position 
        return distance <= Radius + other.Radius;
     }

     public void FixedUpdate()
     {
        UpdateBall2DPhysics(Time.deltaTime);
     }

     private void UpdateBall2DPhysics(float deltaTime)
     {
         float displacementX = Velocity.x * deltaTime; //calculate the displacement of x axis by velocity of x axis multiply the time which time that elapsed the last frame and it will determine how far an object will go
        float displacementY = Velocity.y * deltaTime; //calculate the displacement of x axis by velocity of y axis multiply the time which time that elapsed the last frame and it will determine how far an object will go

        //update the position of x and y axis and calculate the displacement for both x and y axis
        Position.x += displacementX; 
         Position.y += displacementY;

        //update the object transform position to the new value that has been calulated by displacement x and y axis
         transform.position = new Vector2(Position.x, Position.y);
     }

    
 }

