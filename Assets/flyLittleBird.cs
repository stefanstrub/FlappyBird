using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathFunctions;
using ML;

public class flyLittleBird : MonoBehaviour
{
    public gameManager gameManager;
    private Rigidbody2D rigidBody;
    public GameObject pipe;
    public float velocity = 1.2f;
    public float height = 0.5f;
    private float birdWidth = 0.3f;
    public static double[,] Theta = { { -0.1 }, { 0 }, { 1 }, { 0 } };

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float distanceBirdPipe1x = spawn.pipe1.transform.position.x - rigidBody.position.x + birdWidth;
        float distanceBirdPipe2x = spawn.pipe2.transform.position.x - rigidBody.position.x + birdWidth;
        float distanceBirdClosestPipeVertical = rigidBody.position.y - spawn.pipe1.transform.position.y;

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


        double[,] X = { { 1 ,  distanceBirdClosestPipe , distanceBirdClosestPipeVertical, rigidBody.velocity.y } };

        Info.info = (int)(ML.FeedForward.CalculateFeedForward(X, Theta)[0, 0] * 100);
        //Info.info = (int)(Sigmoid.sigmoid(Matrix.MatrixMultiply(X, Theta))[0, 0] * 100);
        //Info.info = (int)(FeedForward.CalculateFeedForward(A, B)[0, 0] * 100);
        //Info2.info2 = (int)(distanceBirdClosestPipeVertical * 100);
        */

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) || Input.touchCount > 0)// || (ML.FeedForward.CalculateFeedForward(X,Theta)[0,0] > 0.5))
        {
            Jump();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
    public void Jump()
    {
        rigidBody.velocity = Vector2.up * velocity;
    }
}
