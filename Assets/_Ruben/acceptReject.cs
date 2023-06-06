using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceptReject : MonoBehaviour
{

    public bool gateUnlock;
    public CharacterData cd;
    // Start is called before the first frame update

    private void Start()
    {
        gateUnlock = false;
    }
    public void Accept()
    {
        cd.accept = true;
        gateUnlock = true;
    }   

    public void Reject()
    {
        cd.accept = false;
        gateUnlock = false;
    }

    public void OnAcceptButtonClicked()
    {
        Accept();
    }

    public void OnRejectButtonClicked()
    {
        Reject();
    }

}
