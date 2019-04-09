using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyShortCuts : MonoBehaviour {

    private EventSystem system;
    public GameObject defaultSelection;
    public Login loginButton;

	// Use this for initialization
	void Start () {
        system = EventSystem.current;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            else
            {
                //Defualt selection
                system.SetSelectedGameObject(defaultSelection);
            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            loginButton.LogIn();
        }
    }
}
