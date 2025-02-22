using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashlight;
    private bool isOn;
    private float waitTime;

    void Update()
    {
        if (waitTime > 0)
            waitTime -= Time.deltaTime;

        if (waitTime <= 0 && Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            flashlight.SetActive(isOn);
            waitTime = 0.5f;
        }
    }
}
