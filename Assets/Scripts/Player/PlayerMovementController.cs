using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField, Min(1)] private float speed;
    [SerializeField] private Transform head;
    public void Move()
    {
        Vector3 direction = CountDirection();
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(direction, ForceMode.VelocityChange);

        if (Mathf.Abs(rbody.velocity.x) > speed)
        {
            rbody.velocity = new Vector3(Mathf.Sign(rbody.velocity.x) * speed, rbody.velocity.y, rbody.velocity.z);
        }
        if (Mathf.Abs(rbody.velocity.z) > speed)
        {
            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, Mathf.Sign(rbody.velocity.z) * speed);
        }
    }
    internal Vector3 CountDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);
        direction = head.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);

        return direction;
    }
}
