using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 7.0f;
    private const float LANE_DISTANCE = 3.0f;
    public int desiredLane = 1; //0=left ; 1=middle ; 2=right

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        //move left
        if (Input.GetKeyDown("q"))
        {
            SwitchLane(false);
        }

        //move right
        if (Input.GetKeyDown("d"))
        {
            SwitchLane(true);
        }

        //Calculate the next position
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        //Move the character
        controller.Move(moveVector * Time.deltaTime);

    }

    private void SwitchLane(bool goingRight)
    {
        //avoid player to go outside the three main line
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }


}
