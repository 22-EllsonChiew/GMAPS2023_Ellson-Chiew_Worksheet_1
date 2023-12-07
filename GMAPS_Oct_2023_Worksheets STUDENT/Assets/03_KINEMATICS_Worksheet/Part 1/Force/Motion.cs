using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 velocity;

    public void FixedUpdate()
    {
        float dt = Time.deltaTime; //create dt variable and give the value of time that elapsed the last frame  

        float dx = velocity.x * dt; //create dx variable and set it to x axis of the velocity multiply the dt of the time
        float dy = velocity.y * dt; //create dy variable and set it to y axis of the velocity multiply the dt of the time
        float dz = velocity.z * dt; //create dz variable and set it to z axis of the velocity multiply the dt of the time

        transform.Translate(new Vector3(dx, dy, dz)); //translate the transform of the gameobject that is dx, dy and dz 
    }
}
