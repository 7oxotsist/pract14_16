using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject BoxPrefab;
    public GameObject SpherePrefab;
    public GameObject PanelMenu;
    public GameObject SpawnObject;
    bool isActive;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)){
            if (!isActive){
                PanelMenu.SetActive(true);
                isActive = true;
            } else {
                PanelMenu.SetActive(false);
                isActive = false;
            }

        }
    }

    public void CreateBox(){
        Instantiate(BoxPrefab, SpawnObject.transform.position, SpawnObject.transform.rotation);
    }

    public void CreateSphere(){
        Instantiate(SpherePrefab, SpawnObject.transform.position, SpawnObject.transform.rotation);
    }

    public void Quit(){
       Application.Quit();
    }
}