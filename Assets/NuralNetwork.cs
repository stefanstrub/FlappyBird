using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathFunctions;

public class NuralNetwork : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        double horizontalDistanceToPipe = 1;
        double verticalDistanceToPipe = 0.5;
        double velocityBird = 1;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("a"))
        {
            flyLittleBird fly = new flyLittleBird();
            fly.Jump();
        }
    }
}
