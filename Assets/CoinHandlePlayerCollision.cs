using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandlePlayerCollision : MonoBehaviour 
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player" && Inventory.Single.CanAdd()) {
            Destroy(gameObject);
            Inventory.Single.AddItem("Coin");
        }
    }


}
