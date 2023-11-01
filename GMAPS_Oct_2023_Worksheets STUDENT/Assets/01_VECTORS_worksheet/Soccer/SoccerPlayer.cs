using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        /*OtherPlayers = FindObjectsOfType<SoccerPlayer>();
        SoccerPlayer[] temp = new SoccerPlayer[OtherPlayers.Length - 1];
        int i = 0;
        foreach (SoccerPlayer p in OtherPlayers)
        {
            if (p != this)
            {
                temp[i] = p;
                i++;
            }
        }
        OtherPlayers = temp;*/

        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray(); 

    }


    float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z + vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        return vector / Magnitude(vector);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return Vector3.Dot(vectorA, vectorB);
    }

    /*SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for(int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = transform.position;
            toPlayer = Normalise(toPlayer);

            float angle = Mathf.Acos(i);

            float dot = Dot(vectorA, vectorB);

            angle = angle * minAngle;

            if(angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }

        return closest;
    }*/

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
                //Calculate the vector from the object to other player object

                Vector3 direction = other.transform.position - transform.position;

                Debug.DrawRay(transform.position, direction, Color.black);
        }
            

            
            
    }

    void Update()
    {
        //DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

         if(IsCaptain)
         {
             //angle += Input.GetAxis("Horizontal") * rotationSpeed;
             //transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
             //Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
         }

        DrawVectors();
    }

}


