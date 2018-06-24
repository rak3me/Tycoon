using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject newCamera;
    public GameObject newCamera2;
    public float smoothTime;

    Camera cam;

    private bool roomEntered = false;
    private bool triggerEntered;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !roomEntered)
        {
            MoveCamera(newCamera);
        }
        else if (other.CompareTag("Player") && roomEntered) 
        {
            MoveCamera(newCamera2);
        }
    }

    IEnumerator MoveCamera(GameObject newSpot)
    {
        cam.transform.position =
                Vector3.SmoothDamp(cam.transform.position, newSpot.transform.position, ref velocity, smoothTime);
        yield return new WaitForSeconds(4f);
        //roomEntered = !roomEntered;
    }

    // Update is called once per frame
    //void Update ()
    //{
    //    if (triggerEntered && !roomEntered)
    //    {
    //        StartCoroutine(moveCamera(newCamera));
    //        roomEntered = true;
    //    }
    //    else if (triggerEntered && roomEntered)
    //    {
    //        StartCoroutine(moveCamera(newCamera2));
    //        roomEntered = false;
    //    }
    //}

    //IEnumerator moveCamera(GameObject newSpot)
    //{
    //    cam.transform.position =
    //            Vector3.SmoothDamp(cam.transform.position, newSpot.transform.position, ref velocity, smoothTime);
    //    yield return new WaitForSeconds(4f);
    //    triggerEntered = false;
    //}
}
