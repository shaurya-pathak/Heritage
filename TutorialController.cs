using UnityEngine;
using TMPro; // Add this namespace to use TextMeshPro components
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public TextMeshProUGUI titleText; // Assign your 'TutorialText' TextMeshProUGUI component here in the inspector
    public TextMeshProUGUI descriptionText; // Assign your 'Description' TextMeshProUGUI component here in the inspector
    public Button continueButton; // Assign your 'Continue' Button component here in the inspector
    private int currentIndex = 0; // To keep track of which step we are on
    public GameObject tutorialCanvas; // Assign your TutorialCanvas GameObject here in the inspector
    public GameObject gameCanvas; // Assign your GameCanvas GameObject here in the inspector


    // Your updated tutorial steps containing title and description
    private (string title, string description)[] tutorialSteps = new (string, string)[]
    {
        ("Congratulations", "You have been elected mayor! You will be making decisions for your town, Heritage City! Press Continue."),
        ("Goal", "You have to optimize all aspects of your city shown above in order to keep your citizens happy."),
        ("Icons", "The icons above represent the different aspects of your city. The first icon represents the happiness of your citizens, the second icon represents the health of your citizens, the third icon represents the wealth of your citizens, and the fourth icon represents the environment of your city."),
        ("Choice", "You will have two choices in every scenario, one in blue, one in green, select your choice with the corresponding button."),
        ("Advice", "This is a game of choice, your choices may seem all fine and dandy in the short term, but in the long term have unintended consequences."),
        ("Ready to Explore", "You're all set, make your decisions wisely, the lives of your citizens depend on it.")
    };

    void Start()
    {
        UpdateTutorialStep(); // Set initial text
        continueButton.onClick.AddListener(ContinueTutorial); // Subscribe to the continue button click event
    }

    public void ContinueTutorial()
    {
        if (currentIndex < tutorialSteps.Length - 1)
        {
            currentIndex++; // Move to the next tutorial step
            UpdateTutorialStep(); // Update the text for the new step
        }
        else
        {
            // Optionally, handle the end of the tutorial
            continueButton.gameObject.SetActive(false); // Hide the continue button
            
            // Deactivate TutorialCanvas and activate GameCanvas
            tutorialCanvas.SetActive(false);
            gameCanvas.SetActive(true);
            
            // Do any other end of tutorial tasks here
        }
    }


    private void UpdateTutorialStep()
    {
        titleText.text = tutorialSteps[currentIndex].title; // Update the title
        descriptionText.text = tutorialSteps[currentIndex].description; // Update the description
    }

    // Call this method to reset the tutorial
    public void ResetTutorial()
    {
        currentIndex = 0; // Reset to the first step
        continueButton.gameObject.SetActive(true); // Show the button again
        UpdateTutorialStep(); // Update the text to the first step
    }
}
