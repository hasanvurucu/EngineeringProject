using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    private List <GameObject> Slots = new List<GameObject>();

    private string[] allTags;

    public Sprite[] collectibleSprites;
    public Sprite defaultSprite;

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
        allTags = new string[3];

        allTags[0] = Tags.WoodAmountTag;
        allTags[1] = Tags.StoneAmountTag;

        allTags[2] = Tags.AxeAmountTag;
    }

    public void SetInventory()
    {
        int j = 0;
        for(int i = 0; i < Inventory.transform.childCount; i++)
        {
            if(i < allTags.Length)
            {
                if(PlayerPrefs.GetInt(allTags[i]) > 0)
                {
                    Slots[j].transform.GetChild(0).GetComponent<Image>().sprite = collectibleSprites[i];
                    Slots[j].transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt(allTags[i]).ToString();
                    j++;
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

        for(; j < Inventory.transform.childCount; j++)
        {
            Slots[j].transform.GetChild(0).GetComponent<Image>().sprite = defaultSprite;
            Slots[j].transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }


}
