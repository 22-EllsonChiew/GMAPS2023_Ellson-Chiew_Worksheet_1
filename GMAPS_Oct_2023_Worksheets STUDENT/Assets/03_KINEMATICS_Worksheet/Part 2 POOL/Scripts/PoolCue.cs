using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing

            //check if ball is null and check if is colliding with from startlinepos x and y axis
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y)) 
            {
                drawnLine = lineFactory.GetLine(ball.transform.position, startLinePos, 1f, Color.black); //draw line from ball transform position from the end of startlinepos with 1f thick and make the color black
                drawnLine.EnableDrawing(true);
            }   
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null) //check if player press mouse button is released and remove the draw line 
        {
            drawnLine.EnableDrawing(false); //disable draw line

            //update the velocity of the white ball.
            Vector2 v_v2 = ball.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // calculate the ball transform position based on the mousePosition input
            HVector2D v = new HVector2D(v_v2); // convert it to HVector2D v with the caluclated ball transform position 
            ball.Velocity = v; //after comverting it assigned it to ball velocity

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
