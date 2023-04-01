using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public Controls playerControls;

    [SerializeField]
    private int maxOfShots;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        playerControls.Player_Map.Shell.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player_Map.Shell.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Calls class ShellAttack and performs hit
        playerControls.Player_Map.Shell.performed += _ =>
        {
            if (gameObject.GetComponent<ShellAttack>().shots.Count < maxOfShots)
                gameObject.GetComponent<ShellAttack>().Shell();
        };
        //playerControls.Attack.Secondary.performed += _ => Secondary();
    }

}
