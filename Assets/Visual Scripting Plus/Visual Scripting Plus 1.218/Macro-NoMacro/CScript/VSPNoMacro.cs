using UnityEngine;

public class VSPNoMacro : MonoBehaviour
{
    public string RemoveNewLine(string origin)
    {
        return origin.Replace("\n", "").Replace("\r", "");
    }
}
