using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;

    [SerializeField] private GameObject destinationO;
    [SerializeField] private Vector3 destination;
    private bool eBoxReady = false;
    private void Start()
    {
        destination = destinationO.transform.position;
    }

    private void Update()
    {
        if (eBoxReady)
        {
            var step = 1.0f * Time.deltaTime;
            elevator.transform.position = Vector3.MoveTowards(elevator.transform.position, destination, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElectricBox"))
        {
            eBoxReady = true;
        }
    }
}
