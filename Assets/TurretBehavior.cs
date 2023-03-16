using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public int turretType;
    public GameManager manager;
    public TurretPlacement parent;
    public GameObject bullet;

    public float moneygain;
    public float cost;
    float timer = 0f;
    public float reloadtime;
    public GameObject firelocation;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if (turretType == 1)
        {
            manager.moneyPerTick += moneygain;
        }
    }

    private void OnDestroy()
    {
        if (turretType == 1)
        {
            manager.moneyPerTick -= moneygain;
        }
        parent.occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (turretType != 1)
        {
            if (timer <= 0)
            {
                Instantiate(bullet, firelocation.transform.position, Quaternion.identity);
                timer = reloadtime;
            }
        }
    }
}

