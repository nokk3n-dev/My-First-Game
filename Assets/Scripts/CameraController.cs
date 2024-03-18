using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraOffset = 2f;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, (player.position.y + cameraOffset), transform.position.z);
    }
}
