using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;
    public float z = -5;
    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }
    private void Update()
    {
        pos = player.position;
        pos.z = z; 
        transform.position = Vector3.Lerp(transform.position, pos, 0.01f);
    }
}
