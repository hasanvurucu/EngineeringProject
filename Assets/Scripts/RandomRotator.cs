using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    Vector3 values;

    private void Start()
    {
        values.x = Random.Range(100, 300);

        int x = Random.Range(0, 2);

        if(x == 0)
        {
            x = 1;
        }else
        {
            x = -1;
        }

        values.x *= x;

        values.y = Random.Range(100, 300);

        x = Random.Range(0, 2);

        if(x == 0)
        {
            x = 1;
        }else
        {
            x = -1;
        }

        values.y *= x;

        values.z = Random.Range(100, 300);

        x = Random.Range(0, 2);

        if (x == 0)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        values.z *= x;
    }

    private void Update()
    {
        transform.Rotate(values * Time.deltaTime);
    }
}
