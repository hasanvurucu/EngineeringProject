using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    private List <GameObject> Slots = new List<GameObject>();

    private string[] allTags;

    [SerializeField] private Sprite[] collectibleSprites;

    void Awake()
    {
        GetSlots();
        GetTags();
    }
    void Update()
    {
        SetInventory();
    }

    private void GetSlots()
    {
        for (int i = 0; i < Inventory.transform.childCount; i++)
        {
            Slots.Add(Inventory.transform.GetChild(i).gameObject);
        }
    }

    private void GetTags()
    {
        allTags = new string[2];

        allTags[0] = Tags.WoodAmountTag;
        allTags[1] = Tags.StoneAmountTag;
    }

    private void SetInventory()
    {
        for(int i = 0; i < Inventory.transform.childCount; i++)
        {
            if(i < allTags.Length)
            {
                if(PlayerPrefs.GetInt(allTags[i]) > 0)
                {
                    Slots[i].transform.GetChild(0).GetComponent<Image>().sprite = collectibleSprites[i];
                    Slots[i].transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt(allTags[i]).ToString();
                }else
                {
                    continue;
                }
            }
            else
            {
                //Do nothing
            }
        }
    }


}
