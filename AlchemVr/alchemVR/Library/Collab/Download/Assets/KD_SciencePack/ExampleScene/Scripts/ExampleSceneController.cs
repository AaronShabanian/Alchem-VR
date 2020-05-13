using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSceneController : MonoBehaviour
{
    // Holds the objects that can be displayed at stage location
    public GameObject[] displayObjects;

    // Holds the camera positions to switch between
    public Transform[] cameraPositions;

    // Counter for current item in the array that is being displayed
    private int currObj;

    // The location for the revealed object to spawn
    public GameObject spawnLoc;

    // For turning off or on all the placed objects in the scene
    public GameObject sceneObjects;
    private bool sceneObjectsON = true;
    

    // Start is called before the first frame update
    void Start()
    {
        currObj = 0;
        foreach (Transform obj in spawnLoc.transform)
        {
            GameObject.Destroy(obj.gameObject);
        }
        GameObject temp = Instantiate(displayObjects[currObj], spawnLoc.transform.position, Quaternion.identity);
        temp.transform.parent = spawnLoc.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function takes a string "dir" which is either A or B. 
    // If A it adds 1 to currObj, if B it subtracts. It then checks to see if the object at displayObjects[currObj] + 1 or - 1 is legal and if so replaces the displayed object with that one
    // by destroying the one attached to the spawnLoc and instantiating a new one based on what is housed in displayObject[currObj]

    public void NewObjectDisplay(string dir)
    {
        if (dir == "A")
        {
            if (currObj < (displayObjects.Length - 1))
            {
                currObj += 1;
                foreach (Transform obj in spawnLoc.transform)
                {
                    GameObject.Destroy(obj.gameObject);
                }
                GameObject temp = Instantiate(displayObjects[currObj], spawnLoc.transform.position, Quaternion.identity);
                temp.transform.parent = spawnLoc.transform;
                temp.transform.rotation = spawnLoc.transform.rotation;
            }
        }
        if (dir == "B")
        {
            if (currObj > 0)
            {
                currObj -= 1;
                foreach (Transform obj in spawnLoc.transform)
                {
                    GameObject.Destroy(obj.gameObject);
                }
                GameObject temp = Instantiate(displayObjects[currObj], spawnLoc.transform.position, Quaternion.identity);
                temp.transform.parent = spawnLoc.transform;
                temp.transform.rotation = spawnLoc.transform.rotation;
            }
        }
    }

    // For quitting the program if run outside of the editor
    public void QuitProgram()
    {
        Application.Quit();
    }

    // For changing the camera position to the three positions 0 = Origin, 1 = Desk Right, 2 = Desk Left
    public void SwapCameraPosition(int i)
    {
        Camera.main.transform.position = cameraPositions[i].transform.position;
        Camera.main.transform.rotation = cameraPositions[i].transform.rotation;
    }

    // For toggling the scene Objects on or off
    public void ToggleSceneObjects()
    {
        if (sceneObjectsON)
        {
            sceneObjectsON = false;
            sceneObjects.SetActive(false);
        } else
        {
            sceneObjectsON = true;
            sceneObjects.SetActive(true);
        }
    }




}
