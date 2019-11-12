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

    [SerializeField]
    private GameObject skipPanel;


    void Awake()
    {
        eyeballPanel.SetActive(false);
        year666Panel.SetActive(false);
        deadAt13Panel.SetActive(false);
        skipPanel.SetActive(false);
    }

    public void StartIntro()
    {
        skipPanel.SetActive(true);
        eyeballPanel.SetActive(true);
    }
 }
