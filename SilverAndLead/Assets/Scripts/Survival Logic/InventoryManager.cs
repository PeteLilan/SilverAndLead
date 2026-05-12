using StarterAssets;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool isInventoryOpen = false;
    StarterAssetsInputs starterAssetsInputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        //make sure inventory is closed at the start of the game
        isInventoryOpen = false;
        InventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.inventory && isInventoryOpen == false) 
        {
            //open inventory
            if (isInventoryOpen == false)
            { 
                InventoryMenu.SetActive(true); 
                isInventoryOpen = true;
            }
            //close inventory
            else if (isInventoryOpen == true)
            {
                InventoryMenu.SetActive(false);
                isInventoryOpen = false;
            }
        }
    }
}
