using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //Cameras possiton should be the same as the cars
    [SerializeReference] Transform carTransform;

    void LateUpdate()
    {
        transform.position = new Vector3(carTransform.position.x, carTransform.position.y, -15);
    }
}
