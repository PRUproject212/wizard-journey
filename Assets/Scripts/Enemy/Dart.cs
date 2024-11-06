using UnityEngine;

public class Dart : MonoBehaviour
{
    public float lifetime = 3f; 

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
