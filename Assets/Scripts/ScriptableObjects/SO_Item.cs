using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item", fileName = "SO_NewItem")]
public class SO_Item : ScriptableObject
{
    public string itemName;
    
    public ItemType ItemType;
    public bool canBeEquipped;
    
    public Sprite inventoryImage;
    
    [Serializable]
    public struct EquippedInfo
    {
        public Sprite equippedSprite;
        public BodyPart bodyPart;
    }
    
    public int buyCost;
    public int sellCost;
}
