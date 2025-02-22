using UnityEngine;

public class Axe : Weapon
{
    public enum AxeState { Idle, Swinging }
    public AxeState currentState = AxeState.Idle;

    [SerializeField]
    private Animator anim;

    public PlayerFeedbacks feedback;

    private float attackRate = 0.5f;
    private float nextAttackTime = 0f;

    private Camera mainCam;

    [SerializeField]
    private LayerMask attackableLayerMask;

    private float attackRange = 2f;
    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (currentState == AxeState.Idle && Input.GetButtonDown("Fire1"))
        {
            Swing();
        }
    }

    private void Swing()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;
            currentState = AxeState.Swinging;

            int r = Random.Range(1, 3);
            anim.Play($"new strike {r}");
           // feedback.Invoke("Axe Swing");

            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, attackRange, attackableLayerMask))
            {
                BaseAI target = hit.collider.gameObject.GetComponent<BaseAI>();
                if (target != null)
                {
                    Debug.Log(hit.collider.gameObject.name);

                    ApplyDamage(target);
                }
            }

            Invoke("ResetState", attackRate);
        }
    }

    private void ResetState()
    {
        currentState = AxeState.Idle;
    }
}
