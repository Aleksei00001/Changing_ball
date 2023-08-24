using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BollTips : ScriptableObject
{
    [SerializeField] private float m_Mass;
    public float mass => m_Mass;

    [SerializeField] private float m_Size;
    public float size => m_Size;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private Color32 m_Color;
    public Color32 color => m_Color;

    [SerializeField] private bool m_Spike;
    public bool spike => m_Spike;

    [SerializeField] private bool m_Bursting;
    public bool bursting => m_Bursting;

    [SerializeField] private bool m_Sticky;
    public bool sticky => m_Sticky;
}
