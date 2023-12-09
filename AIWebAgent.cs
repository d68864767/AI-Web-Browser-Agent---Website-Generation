using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWebAgent : MonoBehaviour
{
    public string GenerateWebsite(string parameters, string content, string interactionData)
    {
        // Parse the input data
        var parsedParameters = JSONParser.ParseParameters(parameters);
        var parsedContent = JSONParser.ParseContent(content);
        var parsedInteractionData = JSONParser.ParseInteractionData(interactionData);

        // Generate the initial website
        var website = WebsiteGenerator.GenerateWebsite(parsedParameters, parsedContent);

        // Populate the website with content
        website = ContentPopulator.PopulateContent(website, parsedContent);

        // Update the website based on the interaction data
        website = WebsiteUpdater.UpdateWebsite(website, parsedInteractionData);

        // Generate the final HTML code
        var html = HTMLGenerator.GenerateHTML(website);

        return html;
    }
}
