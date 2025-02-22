using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Text ammoText;


    private void OnEnable()
    {
        // Subscribe to the value change event
        PlayerAttributes.ON_VALUE_CHANGED += UpdateUI;
    }

    private void OnDisable()
    {
        // Unsubscribe when the object is disabled
        PlayerAttributes.ON_VALUE_CHANGED -= UpdateUI;
    }

    // This method will be called whenever the value changes
    private void UpdateUI()
    {
        ammoText.text = $"{PlayerAttributes.CURRENT_AMMO}/{PlayerAttributes.TOTAL_AMMO}";
    }
}
