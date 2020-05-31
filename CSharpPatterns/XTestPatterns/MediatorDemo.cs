using System;
using System.Collections.Generic;
using System.Text;
using CSharpPatterns.MediatorPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class MediatorDemo
    {
        [Test]
        public void TestChatRoomDemo()
        {
            var room = new ChatRoom();
            var john = new Person("John");
            var jane = new Person("jane");


            room.Join(john);
            room.Join(jane);


            john.Say("Hi");
            jane.Say("Oh, hey John");


            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("Hi Everyone");

            jane.PrivateMessage("Simon", "Glad you could join us");
        }
    }
}
