using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public MouseSelectedObject mouseSelObj;

    
    private GameObject towerObj;

    public Turret turret;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
        
    }

    private void OnMouseEnter() 
    {
        //mouseSelObj.isPlotSelected = true;
        sr.color = hoverColor;
    }

    private void OnMouseExit() 
    {
        //mouseSelObj.isPlotSelected = false;
        sr.color = startColor;
    }

    //private void OnMouseDown() 
    //{
    //    if(UIManager.main.IsHoveringUI()) return;
//
    //    if(towerObj != null) 
    //    {
    //    //    turret.OpenUpgradeUI();
    //        return;
    //    }
//
    //    Tower towerToBuild = BuildManager.main.GetSelectedTower();
//
    //    //if(towerToBuild.cost > LevelManager.main.currency && towerToBuild.stoneCost > LevelManager.main.stone && towerToBuild.woodCost > LevelManager.main.wood)
    //    if(!LevelManager.main.SpendEverything(towerToBuild.cost, towerToBuild.stoneCost, towerToBuild.woodCost))
    //    {
    //        Debug.Log("You can't afford this tower");
    //        
    //        return;
    //    }
    //    else
    //    {
    //        Debug.Log("Se esta pasando el check");
    //        //LevelManager.main.SpendCurrency(towerToBuild.cost, towerToBuild.stoneCost, towerToBuild.woodCost);
    //        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    //        turret = towerObj.GetComponent<Turret>();
    //    }
//
    //    
    //}

    private void OnMouseUp()
    {
        if(UIManager.main.IsHoveringUI()) return;

        if(towerObj != null) 
        {
        //    turret.OpenUpgradeUI();
            return;
        }
        if(mouseSelObj.gameObject.activeInHierarchy)
        {
            Tower towerToBuild = BuildManager.main.GetSelectedTower();

            //if(towerToBuild.cost > LevelManager.main.currency && towerToBuild.stoneCost > LevelManager.main.stone && towerToBuild.woodCost > LevelManager.main.wood)
            if(!LevelManager.main.SpendEverything(towerToBuild.cost, towerToBuild.stoneCost, towerToBuild.woodCost))
            {
                Debug.Log("You can't afford this tower");
                
                return;
            }
            else
            {
                Debug.Log("Se esta pasando el check");
                //LevelManager.main.SpendCurrency(towerToBuild.cost, towerToBuild.stoneCost, towerToBuild.woodCost);
                towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
                turret = towerObj.GetComponent<Turret>();
            }
            mouseSelObj.UnselectTower();
            Debug.Log("Mouse button released over the GameObject.");
        }
        
    }
        
    
}


