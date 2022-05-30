using CollectRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoSingleton<ModelManager>
{
    public List<GameObject> ModelList = new List<GameObject>();
    public int modelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Model in GameObject.FindGameObjectsWithTag("Model"))
        {
            ModelList.Add(Model);
        }

        modelIndex = ModelList.Count;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
