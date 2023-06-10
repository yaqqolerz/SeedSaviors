using UnityEngine;

public class Level2Elevator : MonoBehaviour
{
    private bool isStarted;
    [SerializeField] private GameObject elevator;
    [SerializeField] private GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            var step = 1.0f * Time.deltaTime;
            elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, destination.transform.position, step);
        }
    }
}
