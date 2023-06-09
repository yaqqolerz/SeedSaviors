using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    public BoxCollider2D boxEnvironment;

    private float halfHeight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        /*player = FindObjectOfType<Player>();*/
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, boxEnvironment.bounds.min.x + halfWidth, boxEnvironment.bounds.max.x - halfWidth),
            Mathf.Clamp(player.transform.position.y, boxEnvironment.bounds.min.y + halfHeight, boxEnvironment.bounds.max.y - halfHeight), transform.position.z);
        }
    }
}
