using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxManager : MonoBehaviour
{
    public List<GameObject> Layers; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject layer in Layers) 
        {
            layer.transform.position = new Vector3 (layer.transform.position.x, this.transform.position.y, layer.transform.position.z);
        }
    }
}
