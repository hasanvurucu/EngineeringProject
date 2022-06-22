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

    private bool inventoryHidden;

    void Awake()
    {
        GetSlots();
        GetTags();

        inventoryHidden = false;
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

    public void ShowOrHideInventory()
    {
        float targetScale = 0;
        
        if(inventoryHidden)
        {
            targetScale = 0.5f;
        }else
        {
            targetScale = 0;
        }

        StopCoroutine("ResizeInventory");
        StartCoroutine(ResizeInventory(new Vector3(targetScale, targetScale, 1)));
    }

    IEnumerator ResizeInventory(Vector3 targetScale)
    {
        float t = 0;
        inventoryHidden = !inventoryHidden;

        while(t < 1)
        {
            t += Time.deltaTime * 2;

            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);

            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetScale;
    }

}
