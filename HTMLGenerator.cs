using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTMLGenerator : MonoBehaviour
{
    public static string GenerateHTML(Dictionary<string, object> website)
    {
        string html = "<!DOCTYPE html><html><head><title>AI Generated Website</title></head><body>";

        foreach (var page in website.Keys)
        {
            html += "<div class='page' id='" + page + "'>";
            html += "<h1>" + page + "</h1>";

            var pageContent = (Dictionary<string, object>)website[page];
            foreach (var section in pageContent.Keys)
            {
                html += "<div class='section' id='" + section + "'>";
                html += "<h2>" + section + "</h2>";

                if (section == "Comments")
                {
                    var comments = (List<string>)pageContent[section];
                    foreach (var comment in comments)
                    {
                        html += "<p>" + comment + "</p>";
                    }
                }
                else
                {
                    html += "<p>" + pageContent[section] + "</p>";
                }

                html += "</div>"; // Close section div
            }

            html += "</div>"; // Close page div
        }

        html += "</body></html>";

        return html;
    }
}
