using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject pipe;
    public static GameObject pipe1;
    public static GameObject pipe2;
    public static float height = 0.6f;
    public static float distance = 1f;
    public static float startPosition = 1;
    public static float startHeight = 0.4f;

    // Start is called before the first frame update
    void Start()
    {

        pipe1 = Instantiate(pipe);
        pipe1.transform.position += Vector3.up * Random.Range(-height, height);
        pipe2 = Instantiate(pipe);
        pipe2.transform.position += Vector3.up * Random.Range(-height, height);
        pipe2.transform.position += Vector3.right * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (pipe1.transform.position.x < -1)
        {
            pipe1.transform.position = Vector3.right * startPosition + Vector3.up * startHeight;
            pipe1.transform.position += Vector3.up * Random.Range(-height, height);
        }

        if (pipe2.transform.position.x < -1)
        {
            pipe2.transform.position = Vector3.right * startPosition + Vector3.up * startHeight;
            pipe2.transform.position += Vector3.up * Random.Range(-height, height);
        }

    }
}
