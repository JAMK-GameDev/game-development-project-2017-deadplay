using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Rigidbody rb;
    public Transform target;
    public float smoothing = 5f;

    float cameraDistance = 3.5f;
    float cameraScrollSpeed = 20f;
    float cameraZAxisOffset = 2f;

    float cameraDistanceMax;
    float cameraDistanceMin;
    Vector3 offset;
    Vector3 cameraZoomPos;

    void Start()
    {

		rb = GetComponent<Rigidbody>();

        offset = transform.position - target.position;
        // Calculate maximum and minimum distance
        cameraDistanceMax = transform.position.y + 50f;
        cameraDistanceMin = transform.position.y - 50f;
    }

    void FixedUpdate()
    {
        // Follow the player
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        // Zoom the camera in and out. Might need some polishing later on
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * cameraScrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        cameraZoomPos = new Vector3(transform.position.x, cameraDistance, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, cameraZoomPos, Time.deltaTime);
		rb.MovePosition(transform.position);
        //transform.position = Vector3.Lerp(transform.position, cameraZoomPos, Time.deltaTime);
    }
}
