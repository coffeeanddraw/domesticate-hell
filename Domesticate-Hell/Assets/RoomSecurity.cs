using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSecurity : MonoBehaviour
{
    [SerializeField]
    private GameObject warningUI;

    [SerializeField]
    private GameObject gateCollider;

    [SerializeField]
    private AudioSource accessDeniedAudio;

    [SerializeField]
    private Text textBox;

    [SerializeField]
    private bool fireRoom;

    [SerializeField]
    private bool shadowRoom;

    [SerializeField]
    private bool electricityRoom;

    [SerializeField]
    private bool alchemyRoom;

    private bool attemptToEnter = false;

    void Awake()
    {
        warningUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Magenta is attempting to enter another room");
            if (fireRoom)
            {
                if (!GameManager.HasFireKey)
                {
                    gateCollider.SetActive(true);
                    textBox.text = "WARNING: FIRE TICKET NEEDED FOR ENTRY";
                    warningUI.SetActive(true);
                    accessDeniedAudio.Play();
                    Invoke("TurnOffWarningUI", 3);
                }
                else if (GameManager.HasFireKey)
                {
                    gateCollider.SetActive(false);
                }
            }
            else if (shadowRoom)
            {
                if (!GameManager.HasShadowKey)
                {
                    gateCollider.SetActive(true);
                    textBox.text = "WARNING: SHADOW TICKET NEEDED FOR ENTRY";
                    warningUI.SetActive(true);
                    accessDeniedAudio.Play();
                    Invoke("TurnOffWarningUI", 3);
                }
                else if (GameManager.HasShadowKey)
                {
                    gateCollider.SetActive(false);
                }
            }
            else if (electricityRoom)
            {
                if (!GameManager.HasElectricityKey)
                {
                    gateCollider.SetActive(true);
                    textBox.text = "WARNING: ELECTRICITY TICKET NEEDED FOR ENTRY";
                    warningUI.SetActive(true);
                    accessDeniedAudio.Play();
                    Invoke("TurnOffWarningUI", 3);
                }
                else if (GameManager.HasElectricityKey)
                {
                    gateCollider.SetActive(false);
                }
            }
            else if (alchemyRoom)
            {
                if (!GameManager.HasAlchemyKey)
                {
                    gateCollider.SetActive(true);
                    textBox.text = "WARNING: ALCHEMY TICKET NEEDED FOR ENTRY";
                    warningUI.SetActive(true);
                    accessDeniedAudio.Play();
                    Invoke("TurnOffWarningUI", 3);
                }
                else if (GameManager.HasAlchemyKey)
                {
                    gateCollider.SetActive(false);
                }
            }
        }
    }

    void TurnOffWarningUI()
    {
        warningUI.SetActive(false);
    }
}
