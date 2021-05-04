using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class MascotsThoughtsTests
{
    [UnityTest]
    [TestCase(0)]
    [TestCase(1)]
    public void SetMascotThought(int range)
    {
        GameObject mascotsThoughtsObject = GameObject.Instantiate(new GameObject());
        MascotsThoughts mascotsThoughts = mascotsThoughtsObject.AddComponent<MascotsThoughts>();
        TextMeshProUGUI displayedThought = mascotsThoughtsObject.AddComponent<TextMeshProUGUI>();

        mascotsThoughts.thoughts = new string[] { "test", "test2" };
        mascotsThoughts.displayedThought = displayedThought;

        mascotsThoughts.SetThoughtRandomly(range);
        Assert.That(displayedThought.text, Is.EqualTo(mascotsThoughts.thoughts[range]));
    }
}
