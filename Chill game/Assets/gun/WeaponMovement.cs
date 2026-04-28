using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotationSpeed;
    public Transform rotationGoal;
    public Transform lookIndicator;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime*speed);

        transform.rotation = Quaternion.Lerp(transform.rotation, GetCameraLookDirection(), Time.deltaTime*rotationSpeed);
    }

    private Quaternion GetCameraLookDirection()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            lookIndicator.position = Vector3.Lerp(lookIndicator.position, hit.point, Time.deltaTime*rotationSpeed);
            rotationGoal.LookAt(lookIndicator);
            if (lookIndicator != null)
            {
                lookIndicator.transform.position=hit.point;
            }
            return rotationGoal.rotation;
        }

        return Camera.main.transform.rotation;
    }
}
