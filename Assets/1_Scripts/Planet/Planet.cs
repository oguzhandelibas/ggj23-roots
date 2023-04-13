using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private PlanetData _planetData;

    private void Awake()
    {
        _planetData.SetDiffiulty();
    }

    public PlanetData CurrentPlanetData()
    {
        return _planetData;
    }
}
