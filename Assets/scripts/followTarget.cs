using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    public Transform Target;
    public float smoothspeed = 5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (Target == null) return;

        Vector3 targetposition = Target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetposition, smoothspeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
