using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inputs", fileName = "SO_NewInput")]
public class SO_Inputs : ScriptableObject
{
    public ControllerName ControllerName;
    
    [SerializedDictionary("Input Type", "Event To Trigger")]
    public SerializedDictionary<KeyCode, EventName> inputs;
}
