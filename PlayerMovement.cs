using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OnChangePosition))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 0.1f;
    public Vector2 movementLimitsX;
    public Vector2 movementLimitsY;
    
    public Transform ring;
    public void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.x = Mathf.Clamp((mousePosition.x / Screen.width) * 2 - 1, -1.0F, 1.0F);
            mousePosition.y = Mathf.Clamp((mousePosition.y / Screen.height) * 2 - 1, -1.0F, 1.0F);

            Vector3 targetPosition = new Vector3(mousePosition.x, 0, mousePosition.y);
            var position = transform.position;
            position += targetPosition * sensitivity;

            Vector3 direction = new Vector3(mousePosition.x, 0, mousePosition.y);
            ring.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(new Vector3(90, 0, 0));

            // Limit the movement of the player to the map bounds
            position = new Vector3(
                Mathf.Clamp(position.x, movementLimitsX.x, movementLimitsX.y),
                position.y,
                Mathf.Clamp(position.z, movementLimitsY.x, movementLimitsY.y)
            );
            transform.position = position;
        }
    }

    public IEnumerator AnimateSize(float size)
    {
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        float elapsedTime = 0f;
        Vector3 targetOffset = new Vector3(0, (size/2) + cameraController.offSet.y, (cameraController.offSet.z - (size/2)));
        Vector3 targetScale = new Vector3(size, size, size);
        float waitingTime = 1f;
        while (elapsedTime < waitingTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, elapsedTime / waitingTime);
            cameraController.offSet = Vector3.Lerp(cameraController.offSet, targetOffset, elapsedTime / waitingTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraController.offSet = targetOffset;
        transform.localScale = targetScale;

    }   



}
