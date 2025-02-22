using UnityEngine;

public class BasicEnemy : BaseAI
{
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
