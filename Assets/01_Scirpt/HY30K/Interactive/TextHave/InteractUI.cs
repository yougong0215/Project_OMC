using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractUI : Interactable
{
    [SerializeField] private GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }
    protected override void Interact()
    {
        panel.SetActive(true);
    }
}
