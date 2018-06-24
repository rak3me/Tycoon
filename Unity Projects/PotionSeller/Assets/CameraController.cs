using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject newCamera;
    public int speed;

    Camera cam;

    private bool triggerEntered;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEntered = true;
        }
    }

    // Update is called once per frame
    void Update () {
		if (triggerEntered)
        {
            cam.transform.position = 
                Vector3.Lerp(cam.transform.position, newCamera.transform.position, speed * Time.deltaTime);
        }
	}
}
