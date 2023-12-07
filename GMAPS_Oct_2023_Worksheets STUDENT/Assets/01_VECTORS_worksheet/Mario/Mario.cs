using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;
    public float speed = 3f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //calculate the planet position minus the current position then store the value in gravitydir
        gravityDir = planet.position - transform.position;
        //making new vector3d, and use gravitydir to rearrange, and movedir is then set to value of y and negative x and th z is set to 0f
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        //normalized the vector 
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * speed);
        //the calculated normalized is then stored in gravitynorm
        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        //used singed angel and then exoressed in degress between the vector point, with using vector3.right it will then point to the right and used variable moveDir then use the forwad direction as the point of reference
        float angle = Vector3.SignedAngle(Vector3.right, moveDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));// rotates the rigidbody to specific rotation by using quaternion created by using euler

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);

        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}


