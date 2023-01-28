using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleSystemTests
{
    // A Test behaves as an ordinary method
    //BattleSystem system = new BattleSystem();
    [Test]
    public void ZeroTest()
        {
            // Use the Assert class to test conditions
            //BattleSystem system = new BattleSystem();
            int num = 0;
            int num2 = BattleSystem.returnZero();
            Assert.AreEqual(num,num2);
        }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BattleSystemTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
