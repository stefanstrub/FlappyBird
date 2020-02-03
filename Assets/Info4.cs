using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info4 : MonoBehaviour
{
    public static int info4 = 0;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = info4.ToString();
    }
}
