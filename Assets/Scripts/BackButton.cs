using UnityEngine;
using System;

public class BackButton : MonoBehaviour
{
    public static event Action GoBack;

    public static void SetEventNull()
    {
        GoBack = null;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !Screen.isAnimationRunning)
        {
            if (GoBack == null)
                GoBack += MoveApplicationToBack;

            GoBack();

            GoBack = null;
        }
    }

    private void MoveApplicationToBack()
    {
        print("Move task to back");

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
    }
}