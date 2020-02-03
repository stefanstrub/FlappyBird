using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public static int info = 0;
    // Start is called before the first frame update
    private void Start()
    {
        info = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "x: " + info.ToString();
    }
}
