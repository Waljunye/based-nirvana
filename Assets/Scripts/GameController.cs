using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    private void Update()
    {
        player.PlayerUpdate();
    }
}
