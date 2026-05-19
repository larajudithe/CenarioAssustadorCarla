using UnityEngine;
using System.Collections;

public class DisapearEnemy : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private GameObject scream;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scream.SetActive(false);
    }
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
        scream.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

}
