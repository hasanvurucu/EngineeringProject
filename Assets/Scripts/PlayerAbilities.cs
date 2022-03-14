using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    private GameObject InRangeObject;

    [SerializeField] private Button InteractButton;

    [SerializeField] private GameObject CollectibleWoodPrefab;
    [SerializeField] private GameObject tree02prefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tree")
        {
            InRangeObject = other.transform.parent.gameObject;

            InteractButton.interactable = true;
        }

        if(other.tag == "Stone")
        {
            InRangeObject = other.transform.parent.gameObject;

            InteractButton.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tree")
        {
            InRangeObject = null;

            InteractButton.interactable = false;
        }

        if (other.tag == "Stone")
        {
            InRangeObject = null;

            InteractButton.interactable = false;
        }
    }

    public void BreakOtherObject()
    {
        if(InRangeObject != null)
        {
            GameObject temp = InRangeObject;

            if(temp.tag == "Tree")
            {
                StartCoroutine(BreakingProcess(temp));
            }
            else if(temp.tag == "Stone")
            {
                StartCoroutine(BreakingProcessStone(temp));
            }

            InRangeObject.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = false;

            InteractButton.interactable = false;
        }
    }



    IEnumerator BreakingProcess(GameObject chosenToBreak)
    {
        yield return new WaitForSeconds(0.1f);

        GameObject[] Groups = {
            chosenToBreak.transform.GetChild(0).GetChild(0).gameObject,
            chosenToBreak.transform.GetChild(0).GetChild(1).gameObject,
            chosenToBreak.transform.GetChild(0).GetChild(2).gameObject };

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < Groups[i].transform.childCount; j++)
            {
                Groups[i].transform.GetChild(j).gameObject.AddComponent<MeshCollider>().convex = true;
                Groups[i].transform.GetChild(j).gameObject.AddComponent<Rigidbody>();
                StartCoroutine(DestroyAfterSeconds(Groups[i].transform.GetChild(j).gameObject));
            }

            yield return new WaitForSeconds(1f);
        }

        chosenToBreak.GetComponent<Collider>().enabled = false;
        chosenToBreak.transform.GetChild(1).GetComponent<Collider>().enabled = false;

        chosenToBreak.GetComponent<TreeInfo>().Breaking();
    }

    IEnumerator BreakingProcessStone(GameObject chosenToBreak)
    {
        yield return new WaitForSeconds(0.1f);

        Debug.Log("Breaking stone");
    }

    IEnumerator DestroyAfterSeconds(GameObject given)
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(given);
    }
    
}
