using StarterAssets;
using UnityEngine;
//NEIL PATEL
public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 25f;
    [SerializeField] Camera shootyCamera;
    StarterAssetsInputs starterAssetsInputs;
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            AudioManager.Instance?.PlayShoot();
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