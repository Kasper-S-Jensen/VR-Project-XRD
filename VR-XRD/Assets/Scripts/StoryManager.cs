using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StoryEvent
{
    public string eventName;
    public GameEvent QuestCompleted;
}

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    public List<StoryEvent> storyEvents = new List<StoryEvent>();
    private int currentEventIndex = 0;

    void Awake()
    {
        // Implement the singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateStoryState()
    {
        if (currentEventIndex < storyEvents.Count)
        {
            storyEvents[currentEventIndex].QuestCompleted.Raise(currentEventIndex);
            currentEventIndex++;
        }
        else
        {
            Debug.Log("End of Story");
        }
    }
    
    public int GetCurrentEventIndex()
    {
        return currentEventIndex;
    }
}