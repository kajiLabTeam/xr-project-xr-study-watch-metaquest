using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public void LoginToWatchStudy()
    {
        SceneManager.LoadScene("WatchStudy");
    }
}
