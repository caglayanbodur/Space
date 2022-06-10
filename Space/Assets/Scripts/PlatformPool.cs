using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject combatPlatformPrefab;
    [SerializeField] private GameObject playerPrefab;

    private List<GameObject> platforms = new List<GameObject>();
    private Vector2 platformPosition;
    private Vector2 playerPosition;

    [SerializeField] private float platformDistance;
    void Start()
    {
        CreatPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            PlacePlatform();
        }
        
    }

    void CreatPlatform()
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPosition, quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Mover = true;
        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Mover = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Coin>().OpenCoin();
            }
            NextPlatformPosition();
        }

        GameObject combatPlatform = Instantiate(combatPlatformPrefab, platformPosition, quaternion.identity);
        combatPlatform.GetComponent<CombatPlatform>().Mover = true;
        platforms.Add(combatPlatform);
        NextPlatformPosition();
        
    }

    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            if (platforms[i + 5].gameObject.tag == "Plaform")
            {
                platforms[i + 5].GetComponent<Coin>().ClosedCoin();
                float randomCoin = Random.Range(0.0f, 1.0f);
                if (randomCoin > 0.5f)
                {
                    platforms[i + 5].GetComponent<Coin>().OpenCoin();
                }
            }
            NextPlatformPosition();
        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += platformDistance;
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
            
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;

        }
    }
}
