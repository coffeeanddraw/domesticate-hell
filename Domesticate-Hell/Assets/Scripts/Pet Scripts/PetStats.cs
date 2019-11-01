using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI petStatsTMP;

    private string maxMannaString;

    private string currentMannaString; 

    void Awake()
    {
        petStatsTMP.text = "Hello World";
         //petStatsTMP = GetComponent<TextMeshProUGUI>();
        //textmeshPro.SetText("BlahBlah/nBlah");
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
