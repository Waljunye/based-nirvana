using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private enum RotationType  {
        mouseRotationX = 0,
        mouseRotationY = 1,
        mouseRotationXandY = 2,
        }
    [SerializeField, Min(1)] private float sensivity;
    [SerializeField] Transform head;
    [SerializeField] RotationType localRotationType;
    [SerializeField] float headMinY;
    [SerializeField] float headMaxY;
    private float rotationY;
   public void RotateCamera()
    {
        switch (localRotationType)
        {
            case RotationType.mouseRotationX:
                head.localEulerAngles = new Vector3(0, RotateX(), 0);
                break;
            case RotationType.mouseRotationY:
                head.localEulerAngles = new Vector3(-RotateY(), 0, 0);
                break;
            case RotationType.mouseRotationXandY:
                head.localEulerAngles = new Vector3(-RotateY(), RotateX(), 0);
                break;

        }
    }
    private float RotateX()
    {
        float rotationX = 0;
        rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * sensivity;
        return rotationX;
    }
    private float RotateY()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        return rotationY;
    }
}
