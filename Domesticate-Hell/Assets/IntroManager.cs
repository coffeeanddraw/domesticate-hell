using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private GameObject eyeballPanel;

    [SerializeField]
    private GameObject year666Panel;

    [SerializeField]
    private GameObject deadAt13Panel;


    void Awake()
    {
        eyeballPanel.SetActive(false);
        year666Panel.SetActive(false);
        deadAt13Panel.SetActive(false);
    }

    public void StartIntro()
    {
        eyeballPanel.SetActive(true);
    }
 }
