using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawner : MonoBehaviour
{
    public int numberOfBirds = 3;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBirds; i++)
        {
            Score.score = i;
            GameObject newBird = Instantiate(bird);
            double[,] gene = { { -0.1*i }, { 0 }, { -1 }, { 0 } };
            flyLittleBird.Theta = gene;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
