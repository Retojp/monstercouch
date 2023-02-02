using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIKeyboardSelection : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    int active;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(buttons[0]);
        active = 0;
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            active--;
            if(active < 0) active = buttons.Count - 1;
            EventSystem.current.SetSelectedGameObject(buttons[active]);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            active++;
            if (active >= buttons.Count) active = 0;
            EventSystem.current.SetSelectedGameObject(buttons[active]);
        }
    }
}
