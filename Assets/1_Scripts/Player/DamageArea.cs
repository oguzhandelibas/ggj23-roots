using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public void SetArea(bool active, Vector3 pos)
    {
        gameObject.SetActive(active);
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

}
