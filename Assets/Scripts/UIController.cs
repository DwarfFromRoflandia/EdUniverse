using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnBigStructurePlacement, OnPlayerHousePlacement;
    public Button placeRoadButton, placeHouseButton, placeSpecialButton, placeBigStructureButton, placePlayerHouse;


    public Color outlineColor;
    List<Button> buttonList;

    public void Initialize()
    {
        buttonList = new List<Button> { placeHouseButton, placeRoadButton, placeSpecialButton, placeBigStructureButton, placePlayerHouse };

        placeRoadButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();

        });
        placeHouseButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();

        });
        placeSpecialButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();

        });
        placeBigStructureButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBigStructureButton);
            OnBigStructurePlacement?.Invoke();

        });
        placePlayerHouse.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placePlayerHouse);
            OnPlayerHousePlacement?.Invoke();

        });
    }

    private void ModifyOutline(Button button)
    {
        var outline = button.GetComponent<Outline>();
        outline.effectColor = outlineColor; 
        outline.enabled = true;
    }

    private void ResetButtonColor()
    {
        foreach (Button button in buttonList)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
}
