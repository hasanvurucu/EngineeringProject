using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private Transform craftingPanel;
    [SerializeField] private Transform questPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            CollectCollided(Tags.WoodAmountTag, collision.gameObject);
        }

        if (collision.gameObject.tag == "Stone")
        {
            CollectCollided(Tags.StoneAmountTag, collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CraftingTable")
        {
            StopAllCoroutines();
            StartCoroutine(AppearDisappear(true, craftingPanel));
        }

        if (other.tag == "Erlik")
        {
            StopAllCoroutines();
            StartCoroutine(AppearDisappear(true, questPanel));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CraftingTable")
        {
            StopAllCoroutines();
            StartCoroutine(AppearDisappear(false, craftingPanel));
        }

        if (other.tag == "Erlik")
        {
            StopAllCoroutines();
            StartCoroutine(AppearDisappear(false, questPanel));
        }
    }

    IEnumerator AppearDisappear(bool isAppearing, Transform chosenObj)
    {
        float t = 0;

        Vector3 targetSize;

        if (isAppearing)
            targetSize = Vector3.one;
        else
            targetSize = Vector3.zero;

        while (t < 1)
        {
            t += Time.deltaTime;

            chosenObj.localScale = Vector3.Lerp(chosenObj.localScale, targetSize, t);

            yield return new WaitForEndOfFrame();
        }
    }

    private void CollectCollided(string TagName, GameObject collided)
    {
        int tempAmount = PlayerPrefs.GetInt(TagName);
        tempAmount += 1;
        PlayerPrefs.SetInt(TagName, tempAmount);

        Destroy(collided);
    }
}
