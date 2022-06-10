using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    private List<GameObject> planets = new List<GameObject>();
    private List<GameObject> usedPlanets = new List<GameObject>();

    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");

        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];
            planet.name = sprites[i].name;
            sRenderer.sortingLayerName = "Planet";
            Vector2 position = planet.transform.position;
            position.x = -10;
            planet.transform.position = position;
            planets.Add(planet);
        }
    }


    public void CreatPlanet(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float weight = ScreenCalculator.instance.Width;

        float xValue1 = Random.Range(0.0f, weight);
        float yValue1 = Random.Range(refY, refY + height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);
        
        float xValue2 = Random.Range(-weight, 0.0f);
        float yValue2 = Random.Range(refY , refY + height);
        GameObject planet2 = RandomPlanet();
        planet2.transform.position = new Vector2(xValue2, yValue2);
        
        float xValue3 = Random.Range(-weight, 0.0f);
        float yValue3 = Random.Range(refY - height, refY);
        GameObject planet3 = RandomPlanet();
        planet3.transform.position = new Vector2(xValue3, yValue3);
        
        float xValue4 = Random.Range(-weight, 0.0f);
        float yValue4 = Random.Range(refY - height, refY);
        GameObject planet4 = RandomPlanet();
        planet4.transform.position = new Vector2(xValue4, yValue4);
    }

    GameObject RandomPlanet()
    {
        if (planets.Count > 0)
        {
            int random;
            if (planets.Count == 1)
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, planets.Count - 1);
            }

            GameObject planet = planets[random];
            planets.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(usedPlanets[i]);
            }
            usedPlanets.RemoveRange(0,8);
            int random = Random.Range(0, 8);
            GameObject planet = planets[random];
            planets.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
    }
}
