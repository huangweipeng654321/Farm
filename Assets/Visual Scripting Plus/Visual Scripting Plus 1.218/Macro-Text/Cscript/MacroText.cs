using System.Collections.Generic;
using UnityEngine;

public class MacroText : MonoBehaviour
{
    public List<string> TextAssetToList(TextAsset ta)
    {
        var listToReturn = new List<string>();
        string[] linesFromfile = ta.text.Split("\n"[0]);
        foreach (var line in linesFromfile)
        {
            listToReturn.Add(line);
        }
        return listToReturn;
    }
    public string RemoveNewLine(string origin)
    {
        return origin.Replace("\n", "").Replace("\r", "");
    }
}
