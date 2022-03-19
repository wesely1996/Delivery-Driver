using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 270f;
    [SerializeField] float driveSpeed = 15f;
    [SerializeField] float slowSpeed = 3f;
    [SerializeField] float maxSpeed = 30f;
    [SerializeField] float minSpeed = 7f;
    public bool gameHasEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (!gameHasEnded)
        {
            float steerAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            float driveAmount = Input.GetAxis("Vertical") * driveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, driveAmount, 0);
        }
    }

    public void IncreseSpeed()
    {
        driveSpeed = maxSpeed;
    }

    public void DecreseSpeed()
    {
        if (driveSpeed - slowSpeed > minSpeed)
        {
            driveSpeed -= slowSpeed;
        }
        else
        {
            driveSpeed = minSpeed;
        }
    }

    public void ResetSpeed()
    {
        driveSpeed = 15f;
    }
}
