using UnityEngine;
using System.Collections;
using System;

public class CameraControl : MonoBehaviour
{
    public float DampTime = 0.2f;
    public float ScreenEdgeBuffer = 4f;
    public float MinSize = 6.5f;
    public Transform[] Targets;

    private Camera camera;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;

    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    void FixedUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, DampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int targetCount = 0;
        for (int x = 0; x < Targets.Length; x++)
        {
            averagePos += Targets[x].position;
            targetCount++;
        }
        averagePos /= targetCount;
        averagePos.y = transform.position.y;
        desiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref zoomSpeed, DampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);
        float size = 0f;
        for (int counter = 0; counter < Targets.Length; counter++)
        {
            Vector3 targetLocalPos = transform.InverseTransformPoint(Targets[counter].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.z));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / camera.aspect);
        }
        size += ScreenEdgeBuffer;
        size = Mathf.Max(size, MinSize);
        return size;
    }
}
