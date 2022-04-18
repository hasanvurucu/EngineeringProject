using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingHandler : MonoBehaviour
{
    [SerializeField] private InventoryHandler inventoryHandler;
    [SerializeField] private Button craftButton;

    public Item[] craftingSlots;

    public GameObject craftables;
    public int chosenCraftableSlot = -1;

    private Sprite defaultSprite;

    void Start()
    {
        defaultSprite = craftingSlots[0].imageUI.sprite;
    }

    void Update()
    {
        CheckCraftables();
    }

    [System.Serializable]
    public class Item
    {
        public Image imageUI;
        public int amount;
        public Text amountText;
        public string tag;
    }

    public void Craft()
    {
        if(chosenCraftableSlot >= 0)
        {
            string chosenTag;
            for(int i = 0; i < 4; i++)
            {
                if (craftingSlots[i].amount > 0)
                {
                    chosenTag = craftingSlots[i].tag;

                    int x = PlayerPrefs.GetInt(chosenTag);
                    x -= craftingSlots[i].amount;
                    PlayerPrefs.SetInt(chosenTag, x);

                    craftingSlots[i].imageUI.sprite = defaultSprite;
                    craftingSlots[i].tag = null;
                    craftingSlots[i].amountText.text = "0";
                    craftingSlots[i].amount = 0;
                }
            }

            int temp = PlayerPrefs.GetInt(Tags.AxeAmountTag);
            temp += 1;
            PlayerPrefs.SetInt(Tags.AxeAmountTag, temp);

            chosenCraftableSlot = -1;
        }
    }

    public void AxeRecipe() //Button
    {
        craftingSlots[0].imageUI.sprite = inventoryHandler.collectibleSprites[0];
        craftingSlots[0].amount = 3;
        craftingSlots[0].amountText.text = craftingSlots[0].amount.ToString();
        craftingSlots[0].tag = Tags.WoodAmountTag;

        craftingSlots[1].amount = 0;
        craftingSlots[2].amount = 0;
        craftingSlots[3].amount = 0;

        chosenCraftableSlot = 0;
    }

    private void CheckCraftables()
    {
        if (chosenCraftableSlot == -1)
            craftButton.interactable = false;
        else
            craftButton.interactable = true;


        if (PlayerPrefs.GetInt(Tags.WoodAmountTag) >= 3)
            craftables.transform.GetChild(0).GetComponent<Button>().interactable = true;
        else
            craftables.transform.GetChild(0).GetComponent<Button>().interactable = false;
    }
}
