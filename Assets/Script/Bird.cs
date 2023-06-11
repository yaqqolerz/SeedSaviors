using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class Bird : MonoBehaviour
{
    [SerializeField] private Transform objPrefab; // Prefab of the object
    [SerializeField] private float minInterval = 5f; // Minimum interval between obj spawn
    [SerializeField] private float maxInterval = 7f; // Maximum interval between obj spawn
    //[SerializeField] private float birdSpeed = 5f; // obj speed
    [SerializeField] private float objDuration = 5f; // Duration before destroying the obj prefab
    [SerializeField] List<Transform> positions; //List of destinations
    [SerializeField] float duration = 2;
    int index;
    private float time = 0;
    public bool isnotFinished;
    private void Start()
    {
        isnotFinished = true;
        Move();
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // Instantiate the obj prefab
            Transform obj = Instantiate(objPrefab, transform.position, Quaternion.identity);

            // Destroy the obj prefab after a certain duration
            Destroy(obj.gameObject, objDuration);
        }
    }

    private void Move()
    {
            var pos = positions[index];
            this.transform
                .DOMove(pos.position, duration)
                .onComplete = CheckFinnished;

            index += 1;
            if (index == positions.Count)
                index = 0;
    }

    private void CheckFinnished()
    {
        if (isnotFinished)
        {
            Move();
        }
        else
        {
            return;
        }
    }
}
