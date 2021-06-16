using UnityEngine;
using System;

public class BackButton : MonoBehaviour
{
    public static event Action GoBack;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GoBack == null)
                GoBack += MoveApplicationToBack;
            
            GoBack();

            GoBack = null;
        }
    }

    private void MoveApplicationToBack()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass(Application.identifier);
            activity.Call<bool>("moveTaskToBack", true);
        }
    }
}