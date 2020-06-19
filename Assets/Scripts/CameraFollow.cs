using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private Camera mainCam;
    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthSize;
    private float cameraRatio;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthSize) / 2.0f;
    }

    private void FixedUpdate()
    {
        // limiti di movimento telecamera
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthSize, yMax - camOrthSize);

        // inseguimento del player: followTransform.position.x, followTransform.position.y
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
