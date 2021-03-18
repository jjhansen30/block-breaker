using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Parameters
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float[] constraints;

    //Cached Component References
    float mousePosInUnits;
    Vector2 paddlePos;

    // Update is called once per frame
    void Update()
    {
        //Takes the vector of the paddle and follows the mouse
        //but is constrained within the width of the screen
        mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, constraints[0], constraints[1]);
        transform.position = paddlePos;
    }
}
