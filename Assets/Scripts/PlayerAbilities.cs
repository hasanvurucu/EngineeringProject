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
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tree")
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
            StartCoroutine(BreakingProcess(temp));
            InRangeObject.transform.GetChild(1).gameObject.GetComponent<Collider>().enabled = false;

            InteractButton.interactable = false;

            DropWood(temp);
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

        StartCoroutine(GrowBackAfterSeconds(chosenToBreak.transform));
        
        chosenToBreak.SetActive(false);
    }

    IEnumerator DestroyAfterSeconds(GameObject given)
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(given);

    }

    private void DropWood(GameObject treeObj)
    {
        Vector3 pos = new Vector3(treeObj.transform.position.x, treeObj.transform.position.y + 1, treeObj.transform.position.z);
       
        Instantiate(CollectibleWoodPrefab, pos, treeObj.transform.rotation);
    }

    IEnumerator GrowBackAfterSeconds(Transform given)
    {
        yield return new WaitForSeconds(10f);

        GameObject spawnedObject = Instantiate(tree02prefab, given.position, given.rotation);

        Destroy(given.gameObject);

        spawnedObject.transform.localScale = Vector3.zero;

        float t = 0;

        Vector3 targetScale = new Vector3(0.7f, 0.7f, 0.7f);

        while(t < 1)
        {
            t += Time.deltaTime/2;

            spawnedObject.transform.localScale = Vector3.Lerp(spawnedObject.transform.localScale, targetScale, t);

            yield return new WaitForEndOfFrame();
        }
    }
}
