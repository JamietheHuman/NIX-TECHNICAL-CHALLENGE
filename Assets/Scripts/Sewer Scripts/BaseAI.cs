using MoreMountains.Feedbacks;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    [SerializeField]
    protected int Health = 100;

    [SerializeField]
    protected MMF_Player _damageFeedback;

    private int MaxHealth;

    private void Start()
    {
        MaxHealth = Health;
    }

    public int HealthPercentage()
    { 
        return (Health / MaxHealth) * 100;
    }

    public int HealthAmount()
    {
        return Health;
    }
    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void Damage(int amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Death();
        } else
        {
            if (_damageFeedback != null)
                _damageFeedback.PlayFeedbacks();
        }
    }

    protected virtual void Death() { }
}
