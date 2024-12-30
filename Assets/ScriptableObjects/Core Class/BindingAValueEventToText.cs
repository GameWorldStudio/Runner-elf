/**********************************************************************
 *  Copyright (c) 2023 GameWorldVision. All rights reserved.
 *
 *  This script is the property of GameWorldVision and may not be
 *  reproduced, distributed, or modified without the express
 *  permission of GameWorldVision.
 **********************************************************************/

using TMPro;
using UnityEngine;

[System.Serializable]
public class BindingAValueEventToText<T> : MonoBehaviour
{

    [SerializeField] private AValueEvent<T> so;
    [SerializeField] private TextMeshProUGUI text;

    public AValueEvent<T> SO { get => so; set => this.so = value; }
    public TextMeshProUGUI Text { get => text; set => text = value; }

    public void InitListener()
    {
        SO.onValueChange += UpdateUI;
    }

    public void ResetListener()
    {
        so.onValueChange -= UpdateUI;
    }

    public void UpdateUI(T value = default)
    {
        if(value is float)
        {
            float floatedValue = float.Parse(value.ToString());
            Text.text = floatedValue.ToString("F1");
        }else
            Text.text = value.ToString();
    }

    private void Start()
    {
        if (SO != null)
        {
            InitListener();
            UpdateUI(SO.Value);
        }

    }
}
