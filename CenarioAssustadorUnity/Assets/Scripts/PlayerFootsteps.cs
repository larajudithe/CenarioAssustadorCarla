using UnityEngine;
using System.Collections;

public class PlayerFootsteps : MonoBehaviour
{
   public AudioClip footsteps;
   private PlayerController movement;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent <PlayerController>();
        StartCoroutine(PlayFootSteps());
    }

    // Update is called once per frame
    IEnumerator PlayFootSteps()
    {
        while (true)
        {
            if (movement.moveInput.magnitude > 0.1f)
            {
                AudioController.instance.PlaySFX(footsteps);
            }

            yield return new WaitForSeconds(0.35f);
        }
    }
}
