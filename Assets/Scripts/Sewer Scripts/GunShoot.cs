using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : Weapon
{
    public enum GunState { Idle, Hipfire, ADS, Reloading }
    public GunState currentState = GunState.Idle;

    [SerializeField]
    private Animator anim;

    public PlayerFeedbacks feedback;

    private float fireRate = 0.2f;
    private float nextFireTime = 0f;

    private Camera mainCam;

    [SerializeField]
    private LayerMask shootableLayerMask;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        switch (currentState)
        {
            case GunState.Idle:
                HandleIdleState();
                break;
            case GunState.Hipfire:
                HandleHipfireState();
                break;
            case GunState.ADS:
                HandleADSState();
                break;
        }
    }

    private void HandleIdleState()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(0.2f, "gun shoot", GunState.Hipfire);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("Aim");
            currentState = GunState.ADS;
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentState != GunState.Reloading && PlayerAttributes.CURRENT_AMMO != PlayerAttributes.MAX_AMMO)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void HandleHipfireState()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            currentState = GunState.Idle;
        }
    }

    private void HandleADSState()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(0.3f, "gun close up shoot", currentState);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetTrigger("AimOver");
            currentState = GunState.Idle;
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        if (PlayerAttributes.TOTAL_AMMO <= 0)
            yield break;
        GunState ogState = currentState;
        currentState = GunState.Reloading;
        if (ogState == GunState.ADS)
        {
            anim.SetTrigger("AimReload");
            yield return new WaitForSeconds(1.3f);
        }
        else
        {
            anim.Play("gun reload");
        }
        feedback.Invoke("Gun Reload");
        yield return new WaitForSeconds(3.3f);

        int ammoNeeded = 10 - PlayerAttributes.CURRENT_AMMO; // How much ammo is needed to fill the magazine
        int ammoToReload = Mathf.Min(ammoNeeded, PlayerAttributes.TOTAL_AMMO); // Take only what's available

        PlayerAttributes.CURRENT_AMMO += ammoToReload;
        PlayerAttributes.TOTAL_AMMO -= ammoToReload;

        currentState = GunState.Idle;
    }

    private void Shoot(float rate, string animationTrigger, GunState nextState)
    {
        if(PlayerAttributes.CURRENT_AMMO <= 0 && currentState != GunState.Reloading)
        {
            StartCoroutine(ReloadCoroutine());
            return;
        }
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + rate;
            if (mainCam == null)
            {
                Debug.LogWarning("Main Camera is null");
                return;
            }

            --PlayerAttributes.CURRENT_AMMO;

            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, shootableLayerMask))
            {
                BaseAI target = hit.collider.gameObject.GetComponent<BaseAI>();
               if (target != null)
               {
                    ApplyDamage(target, 100);
               }
            }

            feedback.Invoke("Gun Shoot");
            anim.Play(animationTrigger);
            currentState = nextState;
        }
    }
}
