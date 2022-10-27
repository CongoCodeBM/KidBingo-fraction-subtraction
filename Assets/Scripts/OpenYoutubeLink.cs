using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenYoutubeLink : MonoBehaviour
{
    public void OpenYouTubeKids()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=c5dNa2TVHiQ");
    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
