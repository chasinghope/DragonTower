using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInput : MonoBehaviour
{
    //public InputAction QKey;
    //public InputAction SpaceKey;
    public DialogueCanvas diaCanvas;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            diaCanvas.DoAction_Dialogue();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            diaCanvas.DoAction_ContinueTalk();
        }
    }


    //private void Awake()
    //{
    //    QKey.performed += ctx => { Debug.Log("sssss"); diaCanvas.DoAction_Dialogue(); };
    //    SpaceKey.performed += ctx => { Debug.Log("aaaaa");   diaCanvas.DoAction_ContinueTalk(); };
    //}

    //private void OnEnable()
    //{
    //    QKey.Enable();
    //    SpaceKey.Enable();
    //}


    //private void OnDisable()
    //{
    //    QKey.Disable();
    //    SpaceKey.Disable();
    //}

}
