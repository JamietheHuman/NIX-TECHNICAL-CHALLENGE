using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbacks : MonoBehaviour
{
    private Dictionary<string, MMF_Player> feedbacks = new Dictionary<string, MMF_Player>();

    private void Awake()
    {
        // Grab all child objects and add them to the dictionary using their name as the key
        foreach (Transform child in transform)
        {
            MMF_Player feedback = child.GetComponent<MMF_Player>();
            if (feedback != null)
            {
                feedbacks[child.name] = feedback;
            }
        }
    }

    public void Invoke(string key)
    {
        if (feedbacks.TryGetValue(key, out MMF_Player feedback))
        {
            feedback.PlayFeedbacks();
        }
    }
}
