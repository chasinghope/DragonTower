using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemTest : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionAsset;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private GameObject playerUIPanel;

    // Start is called before the first frame update
    void Start()
    {
        string rebinds = PlayerPrefs.GetString("InputRebindSettings");
        if (!string.IsNullOrEmpty(rebinds))
            inputActionAsset.LoadBindingOverridesFromJson(rebinds);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            Debug.Log("Move:    " + playerInput.actions["Move"].ReadValue<Vector2>());
        }
        if (playerInput.actions["Jump"].triggered)
        {
            Debug.Log("Jump");
        }
        if (playerInput.actions["Interact"].triggered)
        {
            Debug.Log("Interact");
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            playerUIPanel.SetActive(false);
        }

        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            playerUIPanel.SetActive(true);
        }
    }
}
