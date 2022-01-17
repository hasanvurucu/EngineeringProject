using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo : MonoBehaviour
{
    public GameObject treeLogPrefab;
    public int collectedAmount;
    public string collectedTag;
    [SerializeField] private bool isRespawnable;
    [SerializeField] private float respawnTimer;
    public GameObject ownPrefab;

    public void Breaking()
    {
        DropWood();

        if (isRespawnable)
        {
            StartCoroutine(RespawnInSeconds());
        }
    }

    IEnumerator RespawnInSeconds()
    {
        yield return new WaitForSeconds(respawnTimer);

        float t = 0;

        GameObject spawned = Instantiate(ownPrefab, transform.position, transform.rotation);

        spawned.transform.localScale = Vector3.zero;
        
        spawned.GetComponent<TreeInfo>().ownPrefab = ownPrefab;

        Vector3 targetPos = new Vector3(0.7f, 0.7f, 0.7f);

        while(t < 1)
        {
            t += Time.deltaTime;
             
            spawned.transform.localScale = Vector3.Lerp(spawned.transform.localScale, targetPos, t);

            yield return new WaitForEndOfFrame();
        }

        spawned.transform.localScale = targetPos;

        Destroy(gameObject);
    }

    private void DropWood()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

        Instantiate(treeLogPrefab, pos, transform.rotation);
    }

}
