using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;
    public float speed = 3f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir.Normalize();
        gravityDir.Normalize();


        rb.AddForce(-moveDir.ToUnityVector3() * force);
        rb.AddForce(gravityDir.ToUnityVector3() * gravityStrength);

        float angle = gravityDir.FindAngle(new HVector2D(0, -1));
        Debug.Log(Mathf.Rad2Deg * angle);

        rb.MoveRotation(Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle));

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3() * gravityStrength, Color.red);

        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
