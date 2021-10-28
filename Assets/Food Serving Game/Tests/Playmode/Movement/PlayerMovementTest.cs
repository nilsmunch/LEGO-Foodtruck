using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using LegoInterview;

public class PlayerMovementTest
{

    [SetUp]
    public void SetUpTest()
    {
        SceneManager.LoadScene("MainGame");
    }

    [UnityTest]
    public IEnumerator PlayerMovementTestWithEnumeratorPasses()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        Vector3 originPosition = player.transform.position;
        player.movementSpeed = 1f;
        player.MoveInDirection(Vector3.forward);

        Assert.IsTrue(player.transform.position.z > originPosition.z);
        yield return null;
    }
}
