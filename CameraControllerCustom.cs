using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // Singleton instance
    public static CameraController Instance { get; private set; }

    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = this.transform;
        // Check if an instance already exists and if it's not this one, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes the object persistent across scenes
        }

        // Assign the camera transform here or via the inspector
        cameraTransform = GetComponent<Transform>();
    }

    public void MoveCamera(Vector3 newPosition, float duration)
    {
        Debug.Log("MoveCamera() called");
        StartCoroutine(AnimateCamera(newPosition, duration));
        cameraTransform = this.transform;
    }

    private IEnumerator AnimateCamera(Vector3 newPosition, float duration)
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        float time = 0;

        while (time < duration)
        {
            cameraTransform.position = Vector3.Lerp(startPosition, newPosition, time / duration);
            // cameraTransform.rotation = Quaternion.Slerp(startRotation, newRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = newPosition;
        // cameraTransform.rotation = newRotation;
    }

    // Call this method to move the camera from anywhere
    public static void MoveCameraStatic(Vector3 newPosition, float duration)
    {
        if (Instance != null)
        {
            Instance.MoveCamera(newPosition, duration);
        }
        else
        {
            Debug.LogError("CameraController instance not found!");
        }
    }
}
