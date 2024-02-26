using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeFusePosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject fuse1;
    [SerializeField] private GameObject fuse2;
    [SerializeField] private GameObject fuse3;
    [SerializeField] private GameObject fuse4;
    void Start()
    {
        fuse1.transform.position = new Vector3(-59f, 1.2f, -38f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
