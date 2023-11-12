using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public Transform modelToMove; // Assign the model's Transform component in the inspector
    public Transform secondModelToMove; // Assign the model's Transform component in the inspector
    public Vector3 targetPosition; // Set this position in the inspector to where you want the model to move
    public Vector3 secondTargetPosition; // Set this position in the inspector to where you want the model to move
    public float transitionDuration = 5f; // Duration of the transition in seconds
    public GameObject tutorialCanvas; // Assign your TutorialCanvas GameObject here in the inspector
    public GameObject menuCanvas; // Assign your GameCanvas GameObject here in the inspector

    public void StartGame()
    {
        // Start the coroutine to move the model
        StartCoroutine(MoveModelWithRampUp(modelToMove, targetPosition, transitionDuration));
        StartCoroutine(MoveModelWithRampUp(secondModelToMove, secondTargetPosition, transitionDuration));
        menuCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
        // Load the game scene after a delay equal to the transitionDuration
        // Invoke("LoadGameScene", transitionDuration);
    }

    private IEnumerator MoveModelWithRampUp(Transform modelTransform, Vector3 newPosition, float duration)
    {
        Vector3 startPosition = modelTransform.position;
        float time = 0;

        while (time < duration)
        {
            // Using a simple quadratic easing-in function for ramp-up effect
            // The progress will be slow at the start and faster towards the end.
            float progress = (time / duration);
            progress = progress * progress; // Quadratic easing-in

            // Move model to the new position based on the progress
            modelTransform.position = Vector3.Lerp(startPosition, newPosition, progress);

            time += Time.deltaTime;
            yield return null;
        }

        modelTransform.position = newPosition; // Ensure the model ends up at the exact target position
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame() called");
        Application.Quit();
    }
}
