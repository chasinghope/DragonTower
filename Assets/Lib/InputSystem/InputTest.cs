using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private NewControls newControls;



    public const string DefaultJson = "Lib/InputSystem/DefaultInput.json";


    private void Awake()
    {
        //newControls.asset.actionMaps
        newControls = new NewControls();
        newControls.Gameplay.Down.performed += ctx =>
        {
            Debug.Log("Down");
        };

        newControls.Gameplay.Up.performed += ctx =>
        {
            Debug.Log("Up");
        };

        newControls.Gameplay.Left.performed += ctx =>
        {
            Debug.Log("Left");
        };

        newControls.Gameplay.Right.performed += ctx =>
        {
            Debug.Log("Rigth");
        };




        //string defaultInputAsset = File.ReadAllText(Path.Combine(Application.dataPath, DefaultJson));
        //newControls.asset.LoadFromJson(defaultInputAsset);
        //Debug.Log(defaultInputAsset);

    }


    public void OnEnable()
    {
        newControls.Enable();
    }

    public void OnDisable()
    {
        newControls.Disable();
    }

}
