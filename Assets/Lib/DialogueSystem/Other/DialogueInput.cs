using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInput : MonoBehaviour
{
    public InputAction QKey;
    public InputAction SpaceKey;
    public DialogueCanvas diaCanvas;

    private void Awake()
    {
        QKey.performed += ctx => { diaCanvas.DoAction_Dialogue(); };
        SpaceKey.performed += ctx => { diaCanvas.DoAction_ContinueTalk(); };
    }

    private void OnEnable()
    {
        QKey.Enable();
        SpaceKey.Enable();
    }


    private void OnDisable()
    {
        QKey.Disable();
        SpaceKey.Disable();
    }

}
