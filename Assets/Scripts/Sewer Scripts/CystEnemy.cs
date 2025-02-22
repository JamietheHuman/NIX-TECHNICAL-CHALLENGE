using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CystEnemy : BaseAI
{
    public Animator anim;

    protected override void Death()
    {
        StartCoroutine(DoDeath());
    }

    private IEnumerator DoDeath()
    {
        anim.Play("cyst death");
        yield return new WaitForSeconds(2.3f);
        Destroy(gameObject);
    }
}
