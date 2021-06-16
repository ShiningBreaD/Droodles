using System;
using System.Text;

public static class B64X
{
    public static byte[] key = Guid.NewGuid().ToByteArray();

    public static string Encode(string value)
    {
        return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value), key));
    }

    public static string Decode(string value)
    {
        return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), key));
    }

    public static string Encrypt(string value, string key)
    {
        return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(key)));
    }

    public static string Decrypt(string value, string key)
    {
        return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Encoding.UTF8.GetBytes(key)));
    }

    private static byte[] Encode(byte[] bytes, byte[] key)
    {
        int j = 0;
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= key[j];

            if (++j == key.Length)
                j = 0;
        }

        return bytes;
    }
}
