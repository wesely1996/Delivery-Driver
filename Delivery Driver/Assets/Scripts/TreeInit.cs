using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(-30, 30));
        transform.localScale += new Vector3(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f), 0f);
    }
}
