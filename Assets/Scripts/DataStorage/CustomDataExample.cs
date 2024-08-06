using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomDataExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CustomData customData = new CustomData();

        customData.username = "Lizzy";

        customData.address = new Address();
        customData.address.unit = 5;
        customData.address.road = "McDonald rd";
        customData.address.city = "New York";

        customData.books = new Book[2];

        customData.books[0] = new Book();
        customData.books[0].bookName = "Intro to Game Dev";
        customData.books[0].bookAuthor = "James Shark";
        customData.books[0].isDigital = false;
        customData.books[0].yearofPublication = 2005;

        customData.books[1] = new Book();
        customData.books[1].bookName = "Big Bean Book";
        customData.books[1].bookAuthor = "Billie Bob";
        customData.books[1].isDigital = true;
        customData.books[1].yearofPublication = 2022;

        //Data Serialization
        string data = JsonUtility.ToJson(customData);

        Debug.Log($"Json Data = {data}");

        string filePath = Path.Combine(Application.dataPath, "JSONFolder/customJSONFile.json");
        File.WriteAllText(filePath, data );

        string json = File.ReadAllText(filePath);

        //De-Serialize Data
        CustomData deserializedCustomData = JsonUtility.FromJson<CustomData>(json);

        string name = deserializedCustomData.username;
        string firstBookName =  deserializedCustomData.books[0].bookName;
        Debug.Log($"Username = {name}, First Book they are reading is {firstBookName}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
