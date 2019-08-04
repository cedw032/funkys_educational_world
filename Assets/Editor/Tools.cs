using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tools : MonoBehaviour
{

    [MenuItem("Rad Tools/Make Walls Triggers")]
    public static void MakeWallsTriggers() {
        Debug.Log("Do the wall thing");

        GameObject gameObject = GameObject.Find("Walls");
        Debug.Log(gameObject.ToString());

        for (int i = 0; i < gameObject.transform.childCount; ++i) {
            try
            {
                Transform wall = gameObject.transform.GetChild(i);

                // Remove all other children
                for (int j = 1; j < wall.childCount; ++j)
                {
                    DestroyImmediate(wall.GetChild(j));
                }

                GameObject physicsObject = wall.GetChild(0).gameObject;

                GameObject interactionObject = Instantiate<GameObject>(
                    physicsObject, 
                    physicsObject.transform.position,
                    physicsObject.transform.rotation
                );
                interactionObject.transform.parent = wall;

                physicsObject.GetComponent<Collider>().isTrigger = false;
                interactionObject.GetComponent<Collider>().isTrigger = true;

                DestroyImmediate(interactionObject.GetComponent<MeshRenderer>());
            }
            catch(NullReferenceException exception) {
                Debug.LogException(exception);
                //Debug.LogError(exception.ToString());
            } 
        }




    }

}
