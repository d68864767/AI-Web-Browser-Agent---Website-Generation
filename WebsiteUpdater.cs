using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteUpdater : MonoBehaviour
{
    public static Dictionary<string, object> UpdateWebsite(Dictionary<string, object> website, Dictionary<string, object> interactionData)
    {
        foreach (var page in interactionData.Keys)
        {
            foreach (var section in ((Dictionary<string, object>)interactionData[page]).Keys)
            {
                if (section == "Comments")
                {
                    // Add the new comments to the existing ones
                    ((List<string>)website[page][section]).AddRange((List<string>)interactionData[page][section]);
                }
                else
                {
                    // Update the content of the section
                    website[page][section] = interactionData[page][section];
                }
            }
        }

        return website;
    }
}
