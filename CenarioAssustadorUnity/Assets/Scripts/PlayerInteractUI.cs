using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject conteiner;
    [SerializeField] private PlayerInteraction playerInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        conteiner.SetActive(true);
    }

     private void Hide()
    {
         conteiner.SetActive(false);
    }
}
