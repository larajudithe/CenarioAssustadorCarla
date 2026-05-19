using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject bloodOne;
    [SerializeField] private GameObject bloodTwo;
    [SerializeField] private GameObject bloodTri;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cross.SetActive(false);
        bloodOne.SetActive(false);
        bloodTwo.SetActive(false);
        bloodTri.SetActive(false);
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

            cross.SetActive(true);
            bloodOne.SetActive(true);
            bloodTwo.SetActive(true);
            bloodTri.SetActive(true);
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
