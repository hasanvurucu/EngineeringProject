using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private Transform craftingPanel;

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
            StartCoroutine(AppearDisappear(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CraftingTable")
        {
            StopAllCoroutines();
            StartCoroutine(AppearDisappear(false));
        }
    }

    IEnumerator AppearDisappear(bool isAppearing)
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

            craftingPanel.localScale = Vector3.Lerp(craftingPanel.localScale, targetSize, t);

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
