using StarterAssets;
using UnityEngine;
//NEIL PATEL
public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 25f;
    [SerializeField] Camera shootyCamera;
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] float delayShots = 0.5f;
    float lastShotTime = 0f;
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    void Update()
    {
        //Checks for leftmouseclick and if enough time has passed since the last shot
        if (starterAssetsInputs.shoot && Time.time - lastShotTime >= delayShots)
        {
            //Logging current time
            lastShotTime = Time.time;
            //Managing audio
            AudioManager.Instance?.PlayShoot();
            //Using raycast to fire projectile
            RaycastHit hit;
            if (Physics.Raycast(
            shootyCamera.transform.position,
            shootyCamera.transform.forward,
            out hit,
            Mathf.Infinity))
            {
                // Try to get a Health component on what was hit
                Debug.Log("Hit: " + hit.collider.gameObject.name);
                Health health = hit.collider.GetComponent<Health>();
                // Only call TakeDamage if the hit object has Health
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
            starterAssetsInputs.ShootInput(false);
        }
    }
}