using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RuneObject", menuName = "RuneObject")]
public class RuneObject : ScriptableObject
{
    [Serializable]
    public struct AnchorStats
    {
        public bool core;
        public int maxSpellLevel;
        public int minSpellLevel;
        public Vector3 location;
    }


    public string runeName;
    public Sprite rune;
    public int spellLevel;
    public GameObject resultSpell;
    public List<AnchorStats> anchors;
}
