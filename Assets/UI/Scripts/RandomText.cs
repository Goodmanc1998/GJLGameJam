using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RandomText : MonoBehaviour
{
    public string[] textSource = { 
        "Strap in for an action packed shift!",
        "I hope you dont mind the mess in the back",
        "Rallying meets meanial job",
        "I don't think these tyres are street legal",
        "Sponsored by the phantom racer, also known as Jim-Jim the taxi man",
        "Considered a training aid in 14 different countries!",
        "Drive fast, don't come last",
        "Overtime has never been this fun",
        "Oops, looks like someone spilled something in the back",
        "Now comes with easy wipe seats!",
        "At least 3 people think the game is okay!",
        "Saftey comes second! Speed comes first!", 
        "You can't get a ticket if the police can't catch you",
        "Today is the day that you make a mark on the world... A big skid-mark",
        "Day trading isn't as profitable as doing 15 fares in under 4 minutes",
        "Brake pads not included",
        "Seatbelts are optional, but very much recommended",
        "Dont tell your parents you're playing this game",
        "Car go fast, berry fun and cool, I like it",
        "The first entry of a planned 7 series of games",
        "The predecessor of the hit game, absolutely gargantuan gear",
        "Hi my name is Ben and I am trapped in this computer please help me :((",
        "You'll be crying tears of joy from the sheer amount of amusument you will get from this okay game",
        "Can be ran on most devices, not tested though",
        "Traffic laws don't have to be obeyed when you are getting paid",
        "Driting is recommended and smiled upon by your elders", 
        "One session burns 500 calories!",
        "Rated 5 out of 5 on the daytime television show 'mediocre games'"
         };

    public string[] randomText;


    string tempString;

    TextMeshProUGUI textObject;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();

        textObject = this.GetComponent<TextMeshProUGUI>();

        string joinedStrings = " ";

        for(int i=0;i<textSource.Length;i++)
        {
            joinedStrings += textSource[i] + " --- ";
        }

        textObject.text = joinedStrings;
    }

    public void Shuffle()
    {
        for(int i =0;i< textSource.Length -1;i++)
        {
            int rnd = Random.Range(i, textSource.Length);
            tempString = textSource[rnd];
            textSource[rnd] = textSource[i];
            textSource[i] = tempString;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
