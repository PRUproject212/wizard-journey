using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniWizard : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 3f;
    public float followDistance = 1f; 

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
    }
}
