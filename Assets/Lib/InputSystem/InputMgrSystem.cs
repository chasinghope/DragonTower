using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMgrSystem : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionAsset;

    [SerializeField]
    private PlayerInput playerInput;


    private void Awake()
    {
  
    }

    private void OnEnable()
    {
        string rebinds = PlayerPrefs.GetString("InputRebindSettings");
        if (!string.IsNullOrEmpty(rebinds))
            inputActionAsset.LoadBindingOverridesFromJson(rebinds);
            
    }


    private void OnDisable()
    {
        string rebinds = inputActionAsset.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("InputRebindSettings", rebinds);
    }






    public void ResetAllRebindsAction()
    {
        foreach (var inputMap in inputActionAsset.actionMaps)
        {
            inputMap.RemoveAllBindingOverrides();
        }
    }
}
