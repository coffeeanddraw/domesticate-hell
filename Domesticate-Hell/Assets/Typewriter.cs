// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/
// This code is derived from Ashley Godbold's "Mastering UI Development with Unity"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    [SerializeField]
    private Text typewriterText;


    private int positionInString = 0;
    private Coroutine textPusher; 

    void Awake()
    {
        textPusher = StartCoroutine(WriteTheText());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteTheText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WriteTheText()
    {
        for(int i = 0; i <= typewriterText.text.Length; i++)
        {
            typewriterText.text.Substring(0, i);
            positionInString++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
