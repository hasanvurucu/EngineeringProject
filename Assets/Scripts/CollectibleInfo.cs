using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleInfo : MonoBehaviour
{
    //General Info
    private int pieceCount;
    public int resourceLevel; //If too high, player can't break this with non-advanced tools

    //Helper stuff for getting broken
    [SerializeField] private GameObject throwableParticle;
    private Transform objectThrowPoint;

    //Info to provide to player
    public string TagOfObject;

    //Respawner variables
    // -respawntimer
    // -isRespawnable

    private void Awake()
    {
        pieceCount = transform.GetChild(0).childCount;

        if(pieceCount <= 0)
        {
            Debug.Log("Given object has no pieces (pieceCount = 0");
            Destroy(this.gameObject);
        }

        if(objectThrowPoint == null)
        {
            objectThrowPoint = this.gameObject.transform.GetChild(2); //Always check manually if the correct children is chosen
        }
    }

    private void Update()
    {
        if (pieceCount > 0)
            if (Input.GetKeyUp(KeyCode.Space))
                BreakPiece();

    }
    public void BreakPiece()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject thrownParticle = Instantiate(throwableParticle, objectThrowPoint.position, objectThrowPoint.rotation);
            thrownParticle.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-90, 90), 250f, Random.Range(-90, 90)));

            StartCoroutine(DestroyAfterSeconds(thrownParticle));
        }

        pieceCount--;
        transform.GetChild(0).GetChild(pieceCount).gameObject.SetActive(false); //Disabling "GRP" object to make it invisible

        if(pieceCount <= 0)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            Debug.Log("Object is completely broken, start respawner");
        }
    }

    IEnumerator DestroyAfterSeconds(GameObject given)
    {
        yield return new WaitForSeconds(1f);
        Destroy(given);
    }
}
