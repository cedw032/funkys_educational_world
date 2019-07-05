using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeSlot : MonoBehaviour
{
    public Image icon;
    public Image border;

    public string item;
    public bool isSelected;

    private string lastItem;

    public Sprite[] sources;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.item != this.lastItem) {
            border.enabled = this.isSelected;

            switch (item) {
                case "":
                    icon.sprite = sources[0];
                    break;

                default:
                    icon.opacity = ;
                    break;
            }

        }
    }
}
