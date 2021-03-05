using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCandy : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject putPS;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Candy" && other.GetComponent<Candy>().pointPlace==gameObject && other.GetComponent<Candy>().isInPlace==false && other.GetComponent<Candy>().IsTaked==false)
        {
            other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject put = (GameObject)Instantiate(putPS, transform.position, transform.rotation);
            other.GetComponent<Candy>().isInPlace = true;
            GameManager.GetComponent<Game>().PutCandyInPlace();
        }
    }
}
