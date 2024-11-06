using System.Collections;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dartPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float dartSpeed = 5f;

    private void Start()
    {
        StartCoroutine(SpawnDarts());
    }

    private IEnumerator SpawnDarts()
    {
        while (true)
        {
            GameObject dart = Instantiate(dartPrefab, spawnPoint.position, Quaternion.identity);
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            dart.GetComponent<Rigidbody2D>().velocity = randomDirection * dartSpeed;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
