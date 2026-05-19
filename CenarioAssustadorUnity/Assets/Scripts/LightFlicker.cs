using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light light;
    public float minIntensity = 5f;
    public float maxIntensity = 5f;
    public float flickSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent <Light>();
        InvokeRepeating ("Flicker", 0f, flickSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Flicker()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        light.intensity = randomIntensity;
    }
}
