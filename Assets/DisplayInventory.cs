using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public static DisplayInventory Single;

    // Start is called before the first frame update
    void Start()
    {
        Single = this;
    }

    public void SetItems(List<string> items) {
        BeSlot[] slots = transform.GetComponentsInChildren<BeSlot>();
        for (int i = 0; i < slots.Length && i < items.Count; ++i) 
            slots[i].item = items[i];


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
