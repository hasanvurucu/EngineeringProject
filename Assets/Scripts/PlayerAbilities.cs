using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private Button InteractButton;

    [SerializeField] private GameObject CollectibleWoodPrefab;
    [SerializeField] private GameObject tree02prefab;

    [SerializeField] private GameObject AxeToolParentObject;

    public void AxeHit()
    {
        ActivateToolCollider(AxeToolParentObject);
    }

    private void ActivateToolCollider(GameObject givenParent)
    {
        for(int i = 0; i < givenParent.transform.childCount; i++)
        {
            if(givenParent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                StartCoroutine(ToolColliderActivationStatus(givenParent.transform.GetChild(i).gameObject));
                break;
            }
        }
    }

    IEnumerator ToolColliderActivationStatus(GameObject chosenTool)
    {
        yield return new WaitForSeconds(0.1f);
        chosenTool.GetComponent<Collider>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        chosenTool.GetComponent<Collider>().enabled = false;
    }
    
}
