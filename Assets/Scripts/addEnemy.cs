using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addEnemy : MonoBehaviour
{
    private int count;
    private int cooldownBaseEnemy;
    private int cooldownFastEnemy;
    private int cooldownSlowEnemy;

    private int textCooldown;
    private Text theText;

    private int level;
    private int spawnConstant;
    private float spawnSpeed;
    private int numberOfEnemies;

    public GameObject baseEnemy;
    public GameObject fastEnemy;
    public GameObject slowEnemy;
    
    

    void Start()
    {
        count = 0;
        level = 0;
        spawnSpeed = 0.5f;

        textCooldown = 0;

        cooldownBaseEnemy = 1;
        cooldownFastEnemy = 1;
        cooldownSlowEnemy = 1;

        Invoke("baseEnemyCooldown", spawnSpeed * 5.0f * Random.Range(0.0f, 2.0f));
        Invoke("fastEnemyCooldown", spawnSpeed * 10 * Random.Range(0.0f, 2.0f));
        Invoke("slowEnemyCooldown", spawnSpeed * 10 * Random.Range(0.0f, 2.0f));
        NewLevelTextAnimation();
    }

    void Update()
    {
        
        numberOfEnemies = level * 10;

        if (count < numberOfEnemies && cooldownBaseEnemy==0)
        {
            cooldownBaseEnemy = 1;
            spawnBaseEnemy();
            Invoke("baseEnemyCooldown", spawnSpeed* 5.0f * Random.Range(0.0f, 2.0f));
            count++;
        }

        if (count < numberOfEnemies && cooldownFastEnemy == 0)
        {
            cooldownFastEnemy = 1;
            spawnFastEnemy();
            Invoke("fastEnemyCooldown", spawnSpeed * 10 * Random.Range(0.0f, 2.0f));
            count++;
        }

        if (count < numberOfEnemies && cooldownSlowEnemy == 0)
        {
            cooldownSlowEnemy = 1;
            spawnSlowEnemy();
            Invoke("slowEnemyCooldown", spawnSpeed * 10 * Random.Range(0.0f, 2.0f));
            count++;
        }

        Debug.Log("CSE: " + cooldownSlowEnemy + " C: " + count + " NE: " + numberOfEnemies);

        if (count == numberOfEnemies && textCooldown == 0)
        {
            textCooldown = 1;
            NewLevelTextAnimation();
            Invoke("restartCount", 2.0f);
        }
    }

    private void spawnBaseEnemy()
    {

        GameObject newEnemy = Instantiate(baseEnemy, createPosition(), baseEnemy.transform.rotation);

        newEnemy.GetComponent<Rigidbody2D>().MovePosition(createPosition());

    }

    private void baseEnemyCooldown()
    {
        cooldownBaseEnemy = 0; 
    }

    private void spawnFastEnemy()
    {

        GameObject newEnemy = Instantiate(fastEnemy, createPosition(), fastEnemy.transform.rotation);

        newEnemy.GetComponent<Rigidbody2D>().MovePosition(createPosition());

    }

    private void fastEnemyCooldown()
    {
        cooldownFastEnemy = 0;
    }

    private void spawnSlowEnemy()
    {

        GameObject newEnemy = Instantiate(slowEnemy, createPosition(), slowEnemy.transform.rotation);

        newEnemy.GetComponent<Rigidbody2D>().MovePosition(createPosition());

    }

    private void slowEnemyCooldown()
    {
        cooldownSlowEnemy = 0;
    }

    private Vector3 createPosition()
    {

        float randomInScreenWidth = Random.Range(-2.8f,2.8f);
        return (new Vector3(randomInScreenWidth, 7.0f, 0.0f));

    }

    private void restartCount()
    {
        count = 0;
        textCooldown = 0;
    }

    private void NewLevelTextAnimation()
    {
        level++;
        displayText(level);
        Invoke("hideText", 4.0f);
    }

    private void displayText(int level)
    {
        //change text content to represent new level
        theText = gameObject.GetComponent<Text>();
        theText.text = "Level " + level;
    }

    private void hideText()
    {
        //hide text
        gameObject.GetComponent<Text>().text = "";
    }

    
}
