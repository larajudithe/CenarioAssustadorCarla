using UnityEngine;

public class StartLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void LoadMiddleScene()
    {
        SceneMeNAGER.instance.LoadScene("Colonial_Graveyard");
    }
}
