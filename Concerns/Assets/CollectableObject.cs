using UnityEngine;
using System.Collections;

public class CollectableObject : MonoBehaviour, ILookAtHandler {

	public int objectID;
    public GameObject door;
    public GameObject coinlabel;

    //public GameObject Player;

    public bool alk = false;
    public bool meds = false;
    public bool flyer = false;
    public bool coin = false;

   

    void Update()
    {
        //disable door
        if (objectID == 10 && alk && meds && flyer)
        {
            
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void OnLookatEnter()
	{
        //Highlight blue if its not the door
        if (objectID != 10 )
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
	}
    //Stop highlight & stop voice if you look away from the object
	public void OnLookatExit()
	{
        GetComponent<AudioSource>().Stop();
        GetComponent<Renderer>().material.color = Color.white;
    }

	public void OnLookatInteraction()
	{

        if (objectID != 10 && objectID != 20)
        {
            GetComponent<AudioSource>().Play();
        }

        if (objectID == 0)
        {
           door.GetComponent<CollectableObject>().alk = true;
        }
        if (objectID == 1)
        {
            door.GetComponent<CollectableObject>().flyer = true;
        }
        if (objectID == 2)
        {
            door.GetComponent<CollectableObject>().meds = true;
        }
        if (objectID == 4)
        {
            coinlabel.GetComponent<MeshRenderer>().enabled = true;
            door.GetComponent<MeshRenderer>().enabled = true;
        }
        if (objectID == 11)
        {
            door.GetComponent<CollectableObject>().coin = true;
            GetComponent<MeshRenderer>().enabled = false;
            coinlabel.GetComponent<MeshRenderer>().enabled = false;
        }
        if (objectID == 20 && coin)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
