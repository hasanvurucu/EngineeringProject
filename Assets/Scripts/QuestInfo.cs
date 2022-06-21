using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInfo : MonoBehaviour
{
    private string[] QuestDialogs = new string[99];

    private void Awake()
    {
        //Task 1
        QuestDialogs[0] = "Altay (Player): Here I am Erlik, my people are in famine and they are in very bad shape. I want you to get them out of this situation";
        QuestDialogs[1] = "Erlik: I can’t save them young soldier, but maybe you can.";
        QuestDialogs[2] = "Altay (Player): What do you mean";
        QuestDialogs[3] = "Erlik: Although your people have lived in abundance for a long time, it was not enough for them...";
        QuestDialogs[4] = "...They wanted more and started to steal from others. So I unleashed this scourge upon them...";
        QuestDialogs[5] = "...But I will give them a second chance. If you can complete the tasks that I will give you, I will remove the famine of your people.";
        QuestDialogs[6] = "Altay (Player): OK. Tell me and I will do it!";
        QuestDialogs[7] = "Erlik: Your first task is to collect some elements for me.I need the sap of the sacred trees that grow in the nearby forest.Go there and get me what I need!";
        
        //Task 2
        QuestDialogs[8] = "Altay (Player): Here your tree saps,now save my village.";
        QuestDialogs[9] = "Erlik: Not so fast young soldier. Congratulations on completing your first task. But I have another job for you. If you can complete it then I will save your people.";
        QuestDialogs[10] = "Altay (Player): What is it ?";
        QuestDialogs[11] = "Erlik: There are some creatures in the north. This creature damages the crops of the people there and kidnaps their animals...";
        QuestDialogs[12] = "...Kill five creature, bring me their souls, save the people there, and in return, I'll save yours.";
        
        //Finalizing the tasks
        QuestDialogs[13] = "Altay (Player): Erlik! I killed the creature.";
        QuestDialogs[14] = "Erlik: Well done young soldier. Nice to see you're a man of your word..."; 
        QuestDialogs[15] = "...Now that you've learned to help others, I agree to help you. Return back to your village and enjoy the abundance.";

    }

    /*
     
    (Malzeme toplama görevi)
    Altay:Here ý am Erlik, my people are in famine and they are in very bad shape. I want you to get them out of this situation
    Erlik:I can’t save them young soldier,but maybe you can.
    Altay: What do you mean ?
    Erlik: Although your people have lived in abundance for a long time, it was not enough for them.They wanted more and started to steal from others.So I unleashed this scourge upon them.But ý will give them a second chance. if you can complete the tasks that i will give you, I will remove the famine of your people.
    Altay:Okey,tell me and I will do it!
    Erlik:Your first task is to collect some elements for me.I need the sap of the sacred trees that grow in the nearby forest.Go there and get me what I need!


    (Düþman kesme görevi)
    Altay:Here your tree saps,now save my village.
    Erlik:Not so fast young soldier. Congratulations on completing your first task.But I have another job for you.If you can complete it then i will save your people.
    Altay:What is it ?
    Erlik: There's a creature in the north. This creature damages the crops of the people there and kidnaps their animals. Kill this creature, save the people there, and I'll save your people.

    (Yaratýðý öldürdük geldik)
    Altay:Erlik! I killed the creature.
    Erlik:Well done young soldier. Nice to see you're a man of your word. Now that you've learned to help others, I agree to help you. return to your village and enjoy the abundance


    */
}
