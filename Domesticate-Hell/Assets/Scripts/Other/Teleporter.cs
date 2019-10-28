using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject destinationTeleporter;

    [SerializeField]
    private GameObject magenta;

    private Transform destinationLocation;
    private Transform magentaLocation;

    void Awake()
    {
        destinationLocation = destinationTeleporter.GetComponent<Transform>();
        magentaLocation = magenta.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
