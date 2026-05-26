using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneMeNAGER : MonoBehaviour
{

    public static SceneMeNAGER instance;
    [SerializeField] Animator transiAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Awake()
    {
        instance = this;
    }
public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        if (transiAnim != null)
        {
            transiAnim.SetTrigger("End");
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);

        if (transiAnim != null)
        {
            transiAnim.SetTrigger("Start");
        }
    }
}