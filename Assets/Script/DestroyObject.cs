using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
