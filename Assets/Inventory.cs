using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MAX_ITEMS = 4;

    public static Inventory Single;

    private List<string> items;

    // Start is called before the first frame update
    void Start()
    {
        this.items = new List<string>();
        Inventory.Single = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanAdd() {
        return items.Count < Inventory.MAX_ITEMS;
    }

    public bool AddItem(string item) {
        if (this.CanAdd()) {
            this.items.Add(item);
            Debug.Log("ADDED");
            return true;
        }
        return false;
    } 

    public bool HasItem(string item) {
        for (int i = 0; i < this.items.Count; ++i) {
            if (this.items[i] == item) { return true; }            
        }
        return false;
    } 

    public bool UseItem(string item) {
        if (this.HasItem(item))
        {
            this.items.Remove(item);
            return true;
        }
        return false;
    }


}
