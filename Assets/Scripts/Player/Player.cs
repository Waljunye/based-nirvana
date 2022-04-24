using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IMove playerMovement;
    [SerializeField] private PlayerCameraController playerCamera;
    public void PlayerUpdate()
    {
        playerMovement = GetComponent<PlayerMovementController>();
        playerMovement.Move();
        playerCamera.RotateCamera();
          
    }
}
