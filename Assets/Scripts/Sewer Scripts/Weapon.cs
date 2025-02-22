using System.Threading.Tasks;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int _damage = 30;


    protected async void ApplyDamage(BaseAI target, int delay = 0)
    {
        await Task.Delay(delay);
        if (!Application.isPlaying)
            return;
        target.Damage(_damage);
    }
}
