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
    public float respawnCooldown;
    public float respawnTime;
    //public bool isRespawnable; //will be added later
    private Vector3 initialScale;

    private int InitialPieceCount; //Start respawner if piece count is lower than this


    private void Awake()
    {
        pieceCount = transform.GetChild(0).childCount;
        InitialPieceCount = pieceCount;
        initialScale = transform.localScale;

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
        if(pieceCount < InitialPieceCount && pieceCount > 0)
        {
            respawnCooldown += Time.deltaTime;
            if(respawnCooldown >= respawnTime)
            {
                respawnCooldown = 0f;
                StartCoroutine(RespawnTheObject(0f)); //No inside timer, since it is already passed inside this system
                pieceCount = transform.GetChild(0).childCount;
            }
        }
    }

    public void BreakPiece()
    {
        respawnCooldown = 0; //Reset respawning countdown if a hit has been made

        //if "could break it"
        int tempAmount = PlayerPrefs.GetInt(TagOfObject);
        tempAmount += 1; //will be dependent on tool level/success
        PlayerPrefs.SetInt(TagOfObject, tempAmount);

        for (int i = 0; i < 5; i++)
        {
            GameObject thrownParticle = Instantiate(throwableParticle, objectThrowPoint.position, objectThrowPoint.rotation);
            thrownParticle.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-90, 90), 250f, Random.Range(-90, 90)));

            //StartCoroutine(DestroyAfterSeconds(thrownParticle));
            StartCoroutine(MagneticEffect(thrownParticle));
        }

        pieceCount--;
        transform.GetChild(0).GetChild(pieceCount).gameObject.SetActive(false); //Disabling "GRP" object to make it invisible

        if(pieceCount <= 0)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log("Object is completely broken, start respawner");
            StartCoroutine(RespawnTheObject(respawnTime));
        }
    }

    IEnumerator DestroyAfterSeconds(GameObject given)
    {
        yield return new WaitForSeconds(1f);
        Destroy(given);
    }

    IEnumerator MagneticEffect(GameObject given)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        given.GetComponent<Rigidbody>().useGravity = false;

        float t = 0;

        while(t < 1)
        {
            t += Time.deltaTime / 3;

            given.transform.localPosition = Vector3.Lerp(given.transform.localPosition, player.transform.position, t);
            given.transform.localScale = Vector3.Lerp(given.transform.localScale, Vector3.zero, t);

            yield return new WaitForEndOfFrame();
        }

        Destroy(given);
    }

    IEnumerator RespawnTheObject(float insideTimer)
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(insideTimer);

        float t = 0;

        this.gameObject.transform.localScale = Vector3.zero;
        pieceCount = InitialPieceCount;
        
        //Reactivate GRP objects
        for(int i = 0; i < InitialPieceCount; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }

        GetComponent<Collider>().enabled = true;

        while(t < 1)
        {
            t += Time.deltaTime / 2;

            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, initialScale, t);

            yield return new WaitForEndOfFrame();
        }

    }
}
