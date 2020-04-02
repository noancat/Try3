using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class PrefabsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs;
    private void Start()
    {
       
        prefabs = (GameObject[])Resources.LoadAll<GameObject>("Prefabs");
    }
}
