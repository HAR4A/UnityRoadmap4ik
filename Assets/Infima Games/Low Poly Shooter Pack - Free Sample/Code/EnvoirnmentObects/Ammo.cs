using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Ammo Interact");
    }
}
