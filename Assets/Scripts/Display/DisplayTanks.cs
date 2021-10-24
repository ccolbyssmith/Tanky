using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class DisplayTanks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public GameObject blueTank;
    public GameObject greenTank;
    public GameObject redTank;
    public GameObject yellowTank;
    private List<GameObject> tankPrefabs = new List<GameObject>();
    private List<GameObject> tankObjects = new List<GameObject>();
    private Game game;

    void Awake()
    {
        game = gameManager.GetComponent<Game>();
        tankPrefabs.Add(blueTank);
        tankPrefabs.Add(greenTank);
        tankPrefabs.Add(redTank);
        tankPrefabs.Add(yellowTank);
    }

    void Start()
    {
        for (int i = 0; i < tankPrefabs.Count; i++)
        {
            GameObject newTank = Instantiate(tankPrefabs[i], game.getTank(i).getCoordinate(), Quaternion.identity);
            newTank.name = game.getTank(i).color + " Tank";
            tankObjects.Add(newTank);
            tankObjects[i].transform.GetChild(1).GetChild(0).GetComponent<Slider>().maxValue = game.getTank(i).maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        removeTanks();
        updateTanks();
    }

    private void removeTanks()
    {
        for (int i = 0; i < game.getTankRemovalSize(); i++)
        {
            Destroy(tankObjects[game.getTankRemovalIndex(i)]);
            tankObjects.RemoveAt(game.getTankRemovalIndex(i));
        }
        game.resetTankRemovalIndex();
    }

    private void updateTanks()
    {
        for (int i = 0; i < tankObjects.Count; i++)
        {
            tankObjects[i].transform.position = game.getTank(i).getCoordinate();
            tankObjects[i].transform.rotation = game.getTank(i).getRotation();
            tankObjects[i].transform.GetChild(0).rotation = game.getTank(i).getTurretRotation();
            tankObjects[i].transform.GetChild(1).rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            tankObjects[i].transform.GetChild(1).position = new Vector2(game.getTank(i).xPos, game.getTank(i).yPos - 1.8f);
            tankObjects[i].transform.GetChild(1).GetChild(0).GetComponent<Slider>().value = game.getTank(i).health;
            if(tankObjects[i].GetComponent<TankCollision>().passable == false)
            {
                print(tankObjects[i].GetComponent<TankCollision>().passable);
                game.stopTank(i);
            }
        }
    }
}
