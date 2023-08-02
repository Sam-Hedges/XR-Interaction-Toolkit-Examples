using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : Puzzle
{

    [SerializeField] private MeshRenderer[] buttons;
    
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.material.DisableKeyword("_EMISSION");
        }
        ToggleKeyword(buttons[1].material);
    }

    public void ToggleButton1()
    {
        ToggleKeyword(buttons[0].material);
        ToggleKeyword(buttons[1].material);
    }
    
    public void ToggleButton2()
    {
        ToggleKeyword(buttons[0].material);
        ToggleKeyword(buttons[1].material);
        ToggleKeyword(buttons[2].material);

    }
    
    public void ToggleButton3()
    {
        ToggleKeyword(buttons[1].material);
        ToggleKeyword(buttons[2].material);
    }

    private bool ToggleKeyword(Material material)
    {
        if (material.IsKeywordEnabled("_EMISSION"))
        {
            material.DisableKeyword("_EMISSION");
            return false;
        }
        else
        {
            material.EnableKeyword("_EMISSION");
            return true;
        }
    }
    
    private void Update()
    {
        if (buttons[0].material.IsKeywordEnabled("_EMISSION") && buttons[1].material.IsKeywordEnabled("_EMISSION") && buttons[2].material.IsKeywordEnabled("_EMISSION"))
        {
            puzzleComplete = true;
            light.material.DisableKeyword("_EMISSION");
        }
    }
}
