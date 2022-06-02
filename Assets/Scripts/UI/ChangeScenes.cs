using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    public string SceneSet;

    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneSet);
    }
}
