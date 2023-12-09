using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JSONParser : MonoBehaviour
{
    public static Dictionary<string, object> ParseParameters(string parameters)
    {
        var parsedParameters = new Dictionary<string, object>();
        var jsonParameters = JSON.Parse(parameters);

        foreach (KeyValuePair<string, JSONNode> kvp in jsonParameters.AsObject)
        {
            if (kvp.Value.IsArray)
            {
                var list = new List<Dictionary<string, object>>();
                foreach (JSONNode item in kvp.Value.AsArray)
                {
                    list.Add(ParseParameters(item));
                }
                parsedParameters.Add(kvp.Key, list);
            }
            else if (kvp.Value.IsObject)
            {
                parsedParameters.Add(kvp.Key, ParseParameters(kvp.Value));
            }
            else
            {
                parsedParameters.Add(kvp.Key, kvp.Value.Value);
            }
        }

        return parsedParameters;
    }

    public static Dictionary<string, object> ParseContent(string content)
    {
        return ParseParameters(content);
    }

    public static Dictionary<string, object> ParseInteractionData(string interactionData)
    {
        return ParseParameters(interactionData);
    }
}
