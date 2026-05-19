using UnityEngine;
using System.Collections;

public class DisapearEnemy : MonoBehaviour
{
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine("Disappear");
        }
    }

    IEnumerator Disappear()
    {
        Destroy(enemy);
        yield return new  WaitForSeconds(0.4f);
    }

}
