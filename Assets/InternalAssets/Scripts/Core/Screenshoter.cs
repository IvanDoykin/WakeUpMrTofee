using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshoter : MonoBehaviour
{
    [ContextMenu("MakeScreenshot")]
    private void MakeScreenshot()
    {
        Debug.Log(Application.persistentDataPath);
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/screenshot.png");
    }
}
