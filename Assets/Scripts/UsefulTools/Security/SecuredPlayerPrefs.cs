using UnityEngine;

public static class SecuredPlayerPrefs
{
    private static string password = "(AQ/[$-(gvqbVv ? 9jq";

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DeleteKey(string key)
    {
        string eKey = AES.Encrypt(key, password);
        PlayerPrefs.DeleteKey(eKey);
    }

    public static void SetString(string key, string value)
    {
        string eKey = AES.Encrypt(key, password);
        string eValue = AES.Encrypt(value, password);

        PlayerPrefs.SetString(eKey, eValue);
    }

    public static string GetString(string key)
    {
        string eKey = AES.Encrypt(key, password);
        string eValue = PlayerPrefs.GetString(eKey);

        return B64X.Encode(AES.Decrypt(eValue, password));
    }

    public static bool HasKey(string key)
    {
        string eKey = AES.Encrypt(key, password);
        return PlayerPrefs.HasKey(eKey);
    }
}
