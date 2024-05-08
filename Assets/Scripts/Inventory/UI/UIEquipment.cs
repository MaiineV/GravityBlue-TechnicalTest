using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class UIEquipment : MonoBehaviour
{
    [SerializedDictionary("Body Part", "UI Item")]
    public SerializedDictionary<BodyPart, UIItem> equipment;

    public void ReplaceItem(BodyPart bodyPart, Sprite newSprite)
    {
        equipment[bodyPart].ChangeImage(newSprite);
    }
}
