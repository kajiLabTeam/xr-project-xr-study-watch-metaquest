using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public void LoginToStudyWatch()
    {
        SceneManager.LoadScene("StudyWatch");
    }
}
