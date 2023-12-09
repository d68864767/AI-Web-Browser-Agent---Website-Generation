using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPopulator : MonoBehaviour
{
    public static Dictionary<string, object> PopulateContent(Dictionary<string, object> website, Dictionary<string, object> content)
    {
        foreach (var page in website.Keys)
        {
            foreach (var section in ((Dictionary<string, object>)website[page]).Keys)
            {
                if (content.ContainsKey(page) && ((Dictionary<string, object>)content[page]).ContainsKey(section))
                {
                    ((Dictionary<string, object>)website[page])[section] = ((Dictionary<string, object>)content[page])[section];
                }
            }
        }

        return website;
    }
}
