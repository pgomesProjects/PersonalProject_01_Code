using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Delta time is used so that the rotate is updated per second, not per frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
