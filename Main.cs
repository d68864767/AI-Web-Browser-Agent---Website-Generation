using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Create an instance of the AIWebAgent
    private AIWebAgent webAgent;

    // Define the parameters, content, and interaction data
    private string parameters = "{\"pages\": [{\"name\": \"Home\", \"sections\": [\"Article\", \"Author\", \"Comments\"]}, {\"name\": \"About\", \"sections\": [\"Author\"]}]}";
    private string content = "{\"Home\": {\"Article\": \"This is a sample article.\", \"Author\": \"John Doe\", \"Comments\": [\"Great article!\", \"Very insightful.\"]}, \"About\": {\"Author\": \"John Doe has been writing for over 10 years.\"}}";
    private string interactionData = "{\"Home\": {\"Comments\": [\"I learned a lot from this.\"]}}";

    void Start()
    {
        // Initialize the AIWebAgent
        webAgent = new AIWebAgent();

        // Generate the website
        string output = webAgent.GenerateWebsite(parameters, content, interactionData);

        // Print the final HTML code
        Debug.Log(output);
    }
}
