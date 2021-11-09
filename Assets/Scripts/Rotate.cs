using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotationSpeedX = 0f;
    public float RotationSpeedY = 0f;
    public float RotationSpeedZ = 0f;
    private bool IsPositive = false;
    private float RandomSpeed;

    private void Start()
    {
        if (Random.Range(0,2) == 1)
        {
            IsPositive = true;
        }

        RandomSpeed = Random.Range(0, 6);
        if (RotationSpeedX != 0)
            RotationSpeedX += RandomSpeed;
        if (RotationSpeedY != 0)
            RotationSpeedY += RandomSpeed;
        if (RotationSpeedZ != 0)
            RotationSpeedZ += RandomSpeed;
    }
    void FixedUpdate()
    {
        if (IsPositive)
        {
            transform.Rotate(new Vector3(RotationSpeedX / 50, RotationSpeedY / 50, RotationSpeedZ / 50), Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(-RotationSpeedX / 50, -RotationSpeedY / 50, -RotationSpeedZ / 50), Space.Self);
        }
    }
}
