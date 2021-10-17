using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUIPanel : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionAsset;

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
