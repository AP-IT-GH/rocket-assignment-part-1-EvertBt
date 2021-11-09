using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{
    public Transform Target;
    public Transform CameraTarget;
    public Vector3 Offset;
    public float SmoothTime = 2f;

    private void Start()
    {
        if (Offset == new Vector3(0, 0, 0))
        {
            Offset = transform.position - Target.position;
        }
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, SmoothTime);
    }
}
