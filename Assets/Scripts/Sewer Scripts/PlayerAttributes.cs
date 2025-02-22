using System;

public static class PlayerAttributes
{
    private static int health = 100;
    private static int maxAmmo = 10;
    private static int currentAmmo = 10;
    private static int totalAmmo = 100;

    public static Action ON_VALUE_CHANGED;

    public static int HEALTH
    {
        get => health;
        set
        {
            if (health != value)
            {
                health = value;
                ON_VALUE_CHANGED?.Invoke();
            }
        }
    }

    public static int MAX_AMMO
    {
        get => maxAmmo;
        set
        {
            if (maxAmmo != value)
            {
                maxAmmo = value;
                ON_VALUE_CHANGED?.Invoke();
            }
        }
    }

    public static int CURRENT_AMMO
    {
        get => currentAmmo;
        set
        {
            if (currentAmmo != value)
            {
                currentAmmo = value;
                ON_VALUE_CHANGED?.Invoke();
            }
        }
    }

    public static int TOTAL_AMMO
    {
        get => totalAmmo;
        set
        {
            if (totalAmmo != value)
            {
                totalAmmo = value;
                ON_VALUE_CHANGED?.Invoke();
            }
        }
    }
}
