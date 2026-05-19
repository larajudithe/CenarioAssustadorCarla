using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private List<GameObject> objetosAssutadores;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in objetosAssutadores)
        {
            obj.SetActive(false);
        }
  
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out FlowerInteraction flowerInteraction))
                {
                    flowerInteraction.Interaction();
                }


            }
            foreach (GameObject obj in objetosAssutadores)
            {
                obj.SetActive(true);
            }

        }

    }

    public FlowerInteraction GetInteractableObject()
    {
        float interactRange = 1f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out FlowerInteraction flowerInteraction))
            {
                return flowerInteraction;
            }

        }
        return null;
    }

}
