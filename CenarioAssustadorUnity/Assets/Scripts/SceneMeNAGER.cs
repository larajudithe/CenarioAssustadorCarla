using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneMeNAGER : MonoBehaviour
{

    public static SceneMeNAGER instance;
    [SerializeField] Animator transiAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void NextScene()
    {
        StartCoroutine(LoadTheEnd());
    }

    IEnumerator LoadTheEnd()
    {
        transiAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transiAnim.SetTrigger("Start");
    }
}
