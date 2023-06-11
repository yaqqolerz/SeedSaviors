using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform laserPrefab; // Prefab of the laser
    [SerializeField] private Transform target; // Destination for the laser
    [SerializeField] private float minInterval = 1f; // Minimum interval between laser shots
    [SerializeField] private float maxInterval = 5f; // Maximum interval between laser shots
    [SerializeField] private float laserSpeed = 5f; // Laser speed
    [SerializeField] private float laserDuration = 5f; // Duration before destroying the laser prefab

    private void Start()
    {
        StartCoroutine(ShootLaser());
    }

    private IEnumerator ShootLaser()
    {
        while (true)
        {
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // Instantiate the laser prefab
            Transform laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            // Calculate the direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Start moving the laser towards the target
            StartCoroutine(MoveLaser(laser, direction));

            // Destroy the laser prefab after a certain duration
            Destroy(laser.gameObject, laserDuration);
        }
    }

    private IEnumerator MoveLaser(Transform laser, Vector3 direction)
    {
        while (true)
        {
            // Check if the laser is still valid before moving it
            if (laser != null)
            {
                // Move the laser towards the target
                laser.position += direction * laserSpeed * Time.deltaTime;
            }

            yield return null;
        }
    }
}
