using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestHandler : MonoBehaviour
{
    public int currentDialogIndex;
    [SerializeField] private QuestInfo questInfo;
    [SerializeField] private Text questText;
    [SerializeField] private Button nextDialogButton;

    private int mainQuestIndex;


    [SerializeField] private 

    void Start()
    {
        currentDialogIndex = PlayerPrefs.GetInt(Tags.CurrentDialogIndexTag);
        mainQuestIndex = PlayerPrefs.GetInt(Tags.MainQuestIndexTag);

        //questText.text = questInfo.QuestDialogs[currentDialogIndex];
    }


    void Update()
    {
        //Check for Quest[0]
        if(mainQuestIndex == 0 && currentDialogIndex == 7)
        {
            if(PlayerPrefs.GetInt(Tags.WoodAmountTag) < 5)
            {
                nextDialogButton.enabled = false;
            }else
            {
                nextDialogButton.enabled = true;
                mainQuestIndex++;
                PlayerPrefs.SetInt(Tags.MainQuestIndexTag, mainQuestIndex);
            }
        }

        //Check for Quest[1]
        if (mainQuestIndex == 1 && currentDialogIndex == 12)
        {
            if(PlayerPrefs.GetInt(Tags.EnemySoulAmountTag) < 5)
            {
                nextDialogButton.enabled = false;
            }else
            {
                nextDialogButton.enabled = true;
                mainQuestIndex++;
                PlayerPrefs.SetInt(Tags.MainQuestIndexTag, mainQuestIndex);
            }
        }

        //End of the quests
        if(currentDialogIndex == 15)
        {
            nextDialogButton.enabled = false;
        }

    }

    public void NextDialogButton()
    {
        currentDialogIndex++;
        PlayerPrefs.SetInt(Tags.CurrentDialogIndexTag, currentDialogIndex);

        //questText.text = questInfo.QuestDialogs[currentDialogIndex];
    }

    /*
    
    -Get string array from quest info
    -Create a UI object and receive string array values into text object. Put line breaks if necessary.
    -Enable "Next" button until the necessary point, then check for quest necessities.
    -Walk through string array until all quests are done, when the quests are done, hide "Next" button completely.

    */
}
