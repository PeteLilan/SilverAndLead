using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs inputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        inputs = Object.FindAnyObjectByType<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.shoot) 
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
            }
           
            inputs.ShootInput(false);

        }


    }
}
