using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scenarioText; // Assign the TextMeshPro component for the scenario description
    public GameObject[] choiceButtons; // Assign the buttons for the choices
    public TextMeshProUGUI[] choiceTexts; // Assign the TextMeshPro components for the choice texts
    public List<GameObject> scenesToShow;
    public List<Vector3> newPositions; // List of new positions for the game objects


    private List<Scenario> scenarios = new List<Scenario>
    {
        new Scenario
        {
            description = "Your first action as mayor of Heritage Town is to choose a party preference",
            choices = new List<string>
            {
                "Choose the Blue Party",
                "Choose the Green Party"
            }
        },
        new Scenario
        {
            description = "A proposal for a new subway system is on the table, but it's expensive and may displace certain communities.",
            choices = new List<string>
            {
                "Approve the subway for environmental benefits and improved transportation. +5 Environment, +10 Happiness, -5 Wealth",
                "Reject the subway, prioritize community preservation, and explore alternative green transportation options. -5 Happiness, +10 Wealth"
            }
        },
        new Scenario
        {
            description = "The city is facing severe air quality issues, and various interest groups are proposing solutions.",
            choices = new List<string>
            {
                "Enforce strict regulations on vehicles emitting carbon emmissions. -10 Happiness, +5 Environment",
                "Invest in electric vehicle infrastructure. +5 Happiness, -10 Wealth"
            }
        },
        new Scenario
        {
            description = "Uh oh! A massive wildfire is quickly spreading towards the metro area!",
            choices = new List<string>
            {
                "Issue a state of emergency requiring all citizens to evaquate. -10 Happiness, +10 Safety, -10 Wealth",
                "Deploy the national guard and request emergency resources to fight the wildfire. -5 Happiness, +5 Safety, -5 Wealth"
            }
        },
        new Scenario
        {
            description = "The city's education system is struggling, and reforms are needed.",
            choices = new List<string>
            {
                "Invest in technology and teacher training for public schools. +5 Happiness, -5 Wealth",
                "Encourage public-private partnerships for innovative education solutions. +5 Happiness, -5 Wealth"
            }
        },

        new Scenario
        {
            description = "The city would like to approve a proposal for clean energy sources.",
            choices = new List<string>
            {
                "Approve the proposal to build nuclear power generators. +5 Environment, -5 Happiness, -10 Wealth",
                "Approve the proposal to build wind turbines. +5 Environment, -10 Wealth"
            }
        },

        new Scenario
        {
            description = "The homelessness crisis is escalating, and the city needs a comprehensive plan.",
            choices = new List<string>
            {
                "Invest in shelters and social programs to address immediate needs. +5 Safety, -5 Wealth",
                "Develop long-term affordable housing solutions to tackle the root cause. +5 Happiness, -15 Wealth"
            }
        },

        new Scenario
        {
            description = "Constituents are requesting action for a more sustainable future.",
            choices = new List<string>
            {
                "Invest in green spaces and long term solutions for sustainability. +10 Happiness, -10 Wealth",
                "Develop a plan to reduce carbon emissions. +5 Happiness, -5 Wealth"
            }
        },
        
        // Add more scenarios here
    };
    private int currentScenarioIndex = 0;

    void Start()
    {
        DisplayCurrentScenario();
    }

    void DisplayCurrentScenario()
    {
        Scenario currentScenario = scenarios[currentScenarioIndex];
        scenarioText.text = currentScenario.description;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < currentScenario.choices.Count)
            {
                choiceButtons[i].SetActive(true);
                choiceTexts[i].text = currentScenario.choices[i];
            }
            else
            {
                choiceButtons[i].SetActive(false); // Hide button if there are not enough choices
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        // Here you would handle the choice logic, consequences, and transitioning to the next scenario
        // ...
        Debug.Log("Choice made: " + choiceIndex);
        
        

        if (currentScenarioIndex < scenarios.Count - 1)
        {
            GameObject currentScene = scenesToShow[currentScenarioIndex];
            currentScene.SetActive(true);
            Debug.Log("Scenario to show: " + currentScene + " at index " + currentScenarioIndex);

            // Start the linear movement animation
            StartCoroutine(MoveGameObject(currentScene, newPositions[currentScenarioIndex], 6f)); // Move over 6 seconds
            
            if (currentScenarioIndex == 4) {
                currentScene.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

            } else {
                currentScene.transform.localScale = new Vector3(20f, 20f, 20f);

            }

            
            currentScenarioIndex++;
            DisplayCurrentScenario();
        }
        else
        {
            // End of scenarios, handle accordingly
            // ...
        }
    }

    IEnumerator MoveGameObject(GameObject objectToMove, Vector3 newPosition, float duration)
{
    float elapsedTime = 0;
    Vector3 startingPos = objectToMove.transform.position;

    while (elapsedTime < duration)
    {
        objectToMove.transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / duration));
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    objectToMove.transform.position = newPosition; // Ensure the object is exactly at the final position
}


    // Define the Scenario class inside the GameController class
    [System.Serializable]
    public class Scenario
    {
        public string description;
        public List<string> choices;
        public List<GameObject> scenesToShow;
        // You can add more fields here for additional data like consequences
    }
}
