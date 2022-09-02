using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;

public class GameController : MonoBehaviour
{
    public static int PositionCount = 0;
    public static Vector3 DeadPosition = new Vector3(248.360001f, 0.86f, 99.4599991f);
    public static int Score1 = 0;
    public static int Score2 = 0;
    public Animator CollAnimalAn;
    public GameObject CollAnimal;
    public GameObject PenguinFa;
    public Animation PenguinAnimation;
    public GameObject RightHandController;
    public void OnCollisionEnter(Collision animal)
    {
        Debug.Log(PositionCount);
        CollAnimal = animal.gameObject;
        CollAnimalAn = animal.gameObject.GetComponent<Animator>();
        if (PositionCount == 1)
        {
            DeadPosition = new Vector3(248.360001f, 0.56f, 101.4599991f);
        }
        else if (PositionCount == 2)
        {
            DeadPosition = new Vector3(248.360001f, 0.56f, 97.4599991f);
        }
        else if (PositionCount == 3)
        {
            DeadPosition = new Vector3(248.360001f, 0.56f, 103.4599991f);
        }
        else if (PositionCount == 4)
        {
            DeadPosition = new Vector3(248.360001f, 0.56f, 95.4599991f);
        }
        if (animal.gameObject.name == "Penguin")
        {
            PenguinFa = animal.transform.parent.gameObject;
            PenguinFa.GetComponent<BoxCollider>().enabled = false;
            PenguinFa.transform.position = DeadPosition;
            animal.gameObject.transform.position = DeadPosition;
            //animal.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            animal.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (animal.gameObject.name == "Sealdog")
        {
            animal.gameObject.transform.position = DeadPosition + new Vector3(0, 0.34f, 0);
            animal.gameObject.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        else
        {
            animal.gameObject.transform.position = DeadPosition;
            animal.gameObject.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        animal.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        RightHandController.GetComponent<XRRayInteractor>().enabled = false;
        CollAnimalAn.ResetTrigger("live");
        if (LevelController.finalgame == 1)
        {
            if (animal.gameObject.name == "Lion" || animal.gameObject.name == "Zebra")
            {
                Score1++;
                CollAnimalAn.Play("idle", 0, 0f);
                Invoke("AnimalFalse", 2.5f);
            }
            else
            {
                /*if (animal.gameObject.name == "Penguin")
                {
                    PenguinAnimation = CollAnimal.GetComponent<Animation>();
                    PenguinAnimation.Play("")
                }*/
                Invoke("PlayDeadAn", 2);
                Invoke("AnimalFalse", 2.5f);
            }
        }
        else if (LevelController.finalgame == 2)
        {
            if (animal.gameObject.name == "Penguin" || animal.gameObject.name == "Bear" || animal.gameObject.name == "Sealdog")
            {
                Score2++;
                CollAnimalAn.Play("idle", 0, 0f);
                Invoke("AnimalFalse", 2.5f);
            }
            else
            {
                Invoke("PlayDeadAn", 2);
                Invoke("AnimalFalse", 2.5f);
            }
        }
        PositionCount++;
    }

    public void AnimalFalse()
    {
        //CollAnimal.SetActive(false);
        RightHandController.GetComponent<XRRayInteractor>().enabled = true;
    }

    public void PlayDeadAn()
    {
        CollAnimalAn.Play("dead", 0, 0f);
    }

    public static void Reset()
    {
        PositionCount = 0;
        DeadPosition = new Vector3(248.360001f, 0.86f, 99.4599991f);
    }
}
