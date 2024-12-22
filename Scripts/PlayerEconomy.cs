using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public int totalResources = 0;

    public void AddResources(int amount)
    {
        totalResources += amount;
        Debug.Log("Total Resources: " + totalResources);
    }

    public bool SpendResources(int cost)
    {
        if (totalResources >= cost)
        {
            totalResources -= cost;
            Debug.Log("Resources spent: " + cost + ". Remaining: " + totalResources);
            return true;
        }
        else
        {
            Debug.Log("Not enough resources!");
            return false;
        }
    }
}
