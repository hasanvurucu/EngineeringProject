using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wood")
        {
            CollectCollided(Tags.WoodAmountTag, collision.gameObject);
        }

        if(collision.gameObject.tag == "Stone")
        {
            CollectCollided(Tags.StoneAmountTag, collision.gameObject);
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
