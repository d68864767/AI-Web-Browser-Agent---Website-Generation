using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteGenerator : MonoBehaviour
{
    public string GenerateWebsite(string parameters, string content, string interactionData)
    {
        // Parse the input data
        var parsedParameters = JSONParser.ParseParameters(parameters);
        var parsedContent = JSONParser.ParseContent(content);
        var parsedInteractionData = JSONParser.ParseInteractionData(interactionData);

        // Generate the initial website
        var website = new Dictionary<string, object>();
        foreach (var page in (List<Dictionary<string, object>>)parsedParameters["pages"])
        {
            var pageName = (string)page["name"];
            var pageContent = new Dictionary<string, object>();
            foreach (var section in (List<string>)page["sections"])
            {
                pageContent[section] = parsedContent[pageName][section];
            }
            website[pageName] = pageContent;
        }

        // Update the website based on the interaction data
        foreach (var page in parsedInteractionData.Keys)
        {
            foreach (var section in parsedInteractionData[page].Keys)
            {
                if (section == "Comments")
                {
                    // Add the new comments to the existing ones
                    ((List<string>)website[page][section]).AddRange((List<string>)parsedInteractionData[page][section]);
                }
                else
                {
                    // Update the content of the section
                    website[page][section] = parsedInteractionData[page][section];
                }
            }
        }

        // Generate the final HTML code
        var html = HTMLGenerator.GenerateHTML(website);

        return html;
    }
}
