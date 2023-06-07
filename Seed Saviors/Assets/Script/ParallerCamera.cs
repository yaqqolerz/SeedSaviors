using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallerCamera : MonoBehaviour
{
    public Renderer layer1;
    public float layer1Speed;
    public Renderer layer2;
    public float layer2Speed;
    public Renderer layer3;
    public float layer3Speed;
    public Renderer layer4;
    public float layer4Speed;
    public Renderer layer5;
    public float layer5Speed;

    public Transform target;
    float startPosX;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            target = Camera.main.transform;
        startPosX = target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.position.x - startPosX;
        if (layer1 != null)
        {
            var offset = (x * layer1Speed) % 1;
            layer1.material.mainTextureOffset = new Vector2(offset, layer1.material.mainTextureOffset.y);
        }
        if (layer2 != null)
        {
            var offset = (x * layer2Speed) % 1;
            layer2.material.mainTextureOffset = new Vector2(offset, layer2.material.mainTextureOffset.y);
        }
        if (layer3 != null)
        {
            var offset = (x * layer3Speed) % 1;
            layer3.material.mainTextureOffset = new Vector2(offset, layer3.material.mainTextureOffset.y);
        }

        if (layer4 != null)
        {
            var offset = (x * layer4Speed) % 1;
            layer4.material.mainTextureOffset = new Vector2(offset, layer4.material.mainTextureOffset.y);
        }
        if (layer5 != null)
        {
            var offset = (x * layer5Speed) % 1;
            layer5.material.mainTextureOffset = new Vector2(offset, layer5.material.mainTextureOffset.y);
        }
    }
}
