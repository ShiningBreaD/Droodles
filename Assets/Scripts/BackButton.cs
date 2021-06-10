#if PLATFORM_ANDROID

using UnityEngine;
using System;

public class BackButton : MonoBehaviour
{
    private static event Action GoBack;

    public static Action OnGoback
    {
        set
        {
            if (GoBack != null)
                GoBack = null;

            GoBack += value;
        }
    }

    private void OnGUI()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GoBack();
        }
    }
}

#endif