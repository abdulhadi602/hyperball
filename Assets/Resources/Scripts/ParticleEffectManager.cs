using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public GameObject ParticleEffect1, ParticleEffect2 , TrailEffect;
    
    public void SetEffect1()
    {
        ParticleEffect1.SetActive(true);
        ParticleEffect2.SetActive(false);
        TrailEffect.SetActive(false);
    }
    public void SetEffect2()
    { 
        ParticleEffect2.SetActive(true);
        ParticleEffect1.SetActive(false);
        TrailEffect.SetActive(false);
    }
    public void SetEffect3()
    {
        TrailEffect.SetActive(true);
        ParticleEffect2.SetActive(false);
        ParticleEffect1.SetActive(false);
    }
} 
