using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public LayerMask groundLayer;
    public float smoothTime;

    Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 target;
    private RaycastHit hit;
    private Transform player;
    private Ray ray;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        player = GameObject.Find("Player").transform;
        offset = cam.transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(player.position, Vector3.down, out hit, 100, groundLayer))
        {
            target = hit.transform.position + offset;
            
        }
        cam.transform.position =
                Vector3.SmoothDamp(cam.transform.position, target, ref velocity, smoothTime);
    }

}
