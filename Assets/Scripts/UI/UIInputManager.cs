using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actions;
    [SerializeField]
    private GameObject characterStatWindow;

    InputAction openCharacterWindow;

    private bool openingCharacterWindow = false;

    private void Start()
    {
        actions.FindActionMap("ActionMap").Enable();
        openCharacterWindow = actions.FindActionMap("ActionMap").FindAction("Character");
    }

    private void Update()
    {
        if (openCharacterWindow.IsPressed() && !openingCharacterWindow) 
        {
            openingCharacterWindow = true;
            if (!characterStatWindow.activeSelf)
            {
                characterStatWindow.SetActive(true);
            }
            else if (characterStatWindow.activeSelf)
            {
                characterStatWindow.SetActive(false);
            }           
        }
        else if (!openCharacterWindow.IsPressed())
            openingCharacterWindow = false;
    }
}
