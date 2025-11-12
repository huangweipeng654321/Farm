using UnityEngine;

public class VSPSavedVariables : MonoBehaviour
{
    public void SetValueAndSave(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
        PlayerPrefs.Save();
    }
    public void SetValueNoSave(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
    }
    public string GetSaveValue(string name)
    {
        return PlayerPrefs.GetString(name,"null");
    }
    public void SaveAll()
    {
        PlayerPrefs.Save();
    }
}
