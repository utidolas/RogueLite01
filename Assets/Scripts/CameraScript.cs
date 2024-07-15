using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0f, 0f, -5f);
    private Vector3 velocity = Vector3.zero;
    private float timeToReachTarget = .25f;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, timeToReachTarget);
    }
}
