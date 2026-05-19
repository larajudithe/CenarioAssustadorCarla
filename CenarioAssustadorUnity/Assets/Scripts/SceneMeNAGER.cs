using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneMeNAGER : MonoBehaviour
{

    public float changeTime;
    public string  sceneNameOne;
    public string  sceneNameTwo;
    public static SceneMeNAGER instance;
    [SerializeField] Animator  transiAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if ( changeTime <= 0)
        {
            SceneManager.LoadScene(sceneNameOne);
        }
    }

    public void NextScene()
    {
        StartCoroutine(LoadTheEnd());
    }

    IEnumerator LoadTheEnd()
    {
        transiAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNameTwo);
        transiAnim.SetTrigger("Start");
    }
}
