using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    Color Cristo = Color.white;
    public bool occupied = false;
    public GameObject refr;
    public TurretBehavior turretScript;

    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }

    //highlights tile under cursor
    void OnMouseEnter()
    {
        if (manager.buildMode)
        {
            MeshRenderer Barabba = GetComponent<MeshRenderer>();
            Barabba.material.color = Color.black;
        }
    }

    //handles turret placement, creates references between the two objecs
    void OnMouseOver()
    {
        if (manager.buildMode)
        {
            refr = manager.selectedTurret;
            turretScript = refr.GetComponent<TurretBehavior>();
            MeshRenderer Barabba = GetComponent<MeshRenderer>();
            if (Input.GetKeyDown(KeyCode.Mouse0) && occupied == false)
            {
                if (manager.money >= turretScript.cost)
                {
                    refr = Instantiate(manager.selectedTurret, Barabba.gameObject.transform.position + Vector3.up, Quaternion.identity);
                    occupied = true;
                    turretScript = refr.GetComponent<TurretBehavior>();
                    manager.money -= turretScript.cost;
                    turretScript.parent = this;
                }
                manager.buildModeOff();
            }
        }
    }

    //makes tile default color again
    void OnMouseExit()
    {
        MeshRenderer Barabba = GetComponent<MeshRenderer>();
        Barabba.material.color = Cristo;
    }

    void Update()
    {

    }
}
