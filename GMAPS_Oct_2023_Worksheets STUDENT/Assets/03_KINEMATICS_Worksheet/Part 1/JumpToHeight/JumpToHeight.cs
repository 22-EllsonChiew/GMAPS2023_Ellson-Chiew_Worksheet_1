using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class JumpToHeight : MonoBehaviour
 {
    public float Height = 1f;
    Rigidbody rb;

   private void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

   void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        
        float v = 0; 
        float a = Physics.gravity.y; 
        float s = Height;  
        //using SUVAT equation, used u as initial velocity, with v set as 0 multiply by v = 0 - 2 give 0 multiply the physics gravity of y axis and the s height gives 0 value
        float u = Mathf.Sqrt(v * v - 2 * a * s);
        rb.velocity = new Vector3(0, u, 0); // give the rigidbody veloctiy with vector 3D with all o values

        //calculate the force for the object that is required to jump to a certain amount of height by using acceleration physics gravity of y axis
        float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // applied a jumpForce to rigidbody with froce mode of impulse so it will go upwards 
     }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
       {
           Jump();
        }
    }
 }

