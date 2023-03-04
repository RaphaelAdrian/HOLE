using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPosition;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    public GameObject lastHitObstacle;

    public LayerMask obstacleLayerMask;
    
    public 

    void LateUpdate()
    {
        FollowTarget(targetPosition);
    }

    void Update()
    {
        DetectCameraObstacles();
    }

    void FollowTarget(Transform targetPosition)
    {
        Vector3 desiredPosition = targetPosition.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(targetPosition);
    }

    public void DetectCameraObstacles()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f, obstacleLayerMask))
        {
            float lerpTime = 0.5f;
            Material obstacleMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;
            float opacity;
            if (hit.collider)
            {
                lastHitObstacle = hit.collider.gameObject;
                opacity = Mathf.Lerp(1, hit.distance / 5, lerpTime);
                obstacleMaterial.SetFloat("_Opacity", opacity);
            }
        }

        else
        {
            if (lastHitObstacle == null) return;
            GetMaterial(lastHitObstacle).SetFloat("_Opacity", 1f);
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3f, Color.red);
    }
    

    public Material GetMaterial(GameObject gameObject)
    {
        return gameObject.GetComponent<Renderer>().material;
    }
}
