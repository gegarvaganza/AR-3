using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSmoothFollow : MonoBehaviour
{
    public float smoothSpeed = 5f;
    Transform target;

    void Start()
    {
        target = transform.parent;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            Time.deltaTime * smoothSpeed
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            target.rotation,
            Time.deltaTime * smoothSpeed
        );
    }
}

