using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathFunctions;

public class Brain : MonoBehaviour
{
    int geneInput = 2;
    int geneOutput = 1;
    public double[,] gene = { { -0.1 }, { 1 }};
    public double[,] zeroMatrix = { { 0 }, { 0 }};
    private Rigidbody2D rigidBody;
    public GameObject pipe;
    public float velocity = 1.3f;
    public float height = 0.5f;
    private float birdWidth = 0.3f;
    Vector3 startPosition;  
    public float timeAlive = 0;
    public float distanceTravelled = 0;  
    public bool alive = true;
    public float distanceBirdClosestPipeVertical;
    
	public void Init()
	{
        this.gene = zeroMatrix;
        //initialise DNA
        this.gene[0,0] = Random.Range(-1.0f, 1.0f);
        this.gene[1,0] = Random.Range(-1.0f, 1.0f);
        //this.gene[2,0] = Random.Range(-1.0f, 1.0f);
        //this.gene[3,0] = Random.Range(-1.0f, 1.0f);
        startPosition = this.transform.position;
        rigidBody = this.GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D colllision)
    {
        this.alive = false;

        Physics.IgnoreCollision(this.GetComponent<Collider>(), GetComponent<Collider>());
    }


    void Update()
    {
        if(!alive) return;

        timeAlive = PopulationManager.elapsed;

        float distanceBirdPipe1x = spawn.pipe1.transform.position.x - rigidBody.position.x + birdWidth;
        float distanceBirdPipe2x = spawn.pipe2.transform.position.x - rigidBody.position.x + birdWidth;
        distanceBirdClosestPipeVertical = rigidBody.position.y - spawn.pipe1.transform.position.y;

        float distanceBirdClosestPipe = Mathf.Min(distanceBirdPipe1x, distanceBirdPipe2x);
        if (distanceBirdClosestPipe < 0)
        {
            distanceBirdClosestPipe = Mathf.Max(distanceBirdPipe1x, distanceBirdPipe2x);
        }
        if (distanceBirdClosestPipe == distanceBirdPipe1x)
        {
            distanceBirdClosestPipeVertical = rigidBody.position.y - spawn.pipe1.transform.position.y;
        }
        else
        {
            distanceBirdClosestPipeVertical = rigidBody.position.y - spawn.pipe2.transform.position.y;
        }


        double[,] X = { { 1, distanceBirdClosestPipeVertical } }; // rigidBody.velocity.y

        Info.info = (int)(ML.FeedForward.CalculateFeedForward(X, gene)[0, 0] * 100);



        if (Input.GetKeyDown("space") || Input.touchCount > 0 || (ML.FeedForward.CalculateFeedForward(X, gene)[0, 0] > 0.5))
        {
            Jump();
        }
    }
    public void Jump()
    {
        rigidBody.velocity = Vector2.up * velocity;
    }
    public void mutate()
    {
        double randomNumber = Random.Range(0.0f,1.0f);
        double mutationRate = 0.8;
        if (randomNumber > mutationRate)
        {

            int m = this.gene.GetLength(0);
            int n = this.gene.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    this.gene[i, j] = mutateWeight(this.gene[i, j]);
                }
            }
        }
    }
    private double mutateWeight(double weight)
    {
        double rand2 = Random.Range(0.0f,1.0f);
        if (rand2 < 0.1)
        { //10% of the time completely change the this.weight
            weight = Random.Range(-1.0f,1.0f);
        }
        else
        { //otherwise slightly change it
            double mean = 0;
            double stdDev = 0.1;

            double x1 = 1 - Random.Range(0.0f, 1.0f);
            double x2 = 1 - Random.Range(0.0f, 1.0f);

            double y1 = System.Math.Sqrt(-2.0 * System.Math.Log(x1)) * System.Math.Cos(2.0 * System.Math.PI * x2);
            double randomGaussianValue = y1 * stdDev + mean;

            weight += (randomGaussianValue);
            //keep this.weight between bounds
            if (weight > 1)
            {
                weight = 1;
            }
            if (weight < -1)
            {
                weight = -1;

            }
        }
        return weight;
    }
}

