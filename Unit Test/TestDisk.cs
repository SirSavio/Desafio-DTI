using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Models;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Inicialize()
        {
            
            Disk disk = new Disk("A", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("B", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("C", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("D", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("E", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("F", "1985", "C");
            DiskController.Create(disk);
            disk = new Disk("G", "1985", "C");
            DiskController.Create(disk);

        }
        
        [Test]
        [TestCase("Thriller", "1982", "Michael")]
        [TestCase("A", "1952", "M")]
        public void CreateDisk_True(string title, string release, string groupName)
        {
            Disk disk = new Disk(title, release, groupName);
            KeyValuePair<int, Disk> ds = DiskController.Create(disk);
            Assert.Pass();
        }
        
        [Test]
        [TestCase("", "1982", "Michael")]
        [TestCase("Thriller", "", "Michael")]
        [TestCase("Thriller", "1", "Michael")]
        [TestCase("Thriller", "11", "Michael")]
        [TestCase("Thriller", "111", "Michael")]
        [TestCase("Thriller", "11111", "Michael")]
        [TestCase("Thriller", "1111", "")]
        public void CreateDisk_False(string title, string release, string groupName)
        {
            try
            {
                Disk disk = new Disk(title, release, groupName);
                KeyValuePair<int, Disk> ds = DiskController.Create(disk);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void GetDisk_True(int id)
        {
            KeyValuePair<int, Disk> disk = DiskController.GetDisk(id);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void GetDisk_False(int id)
        {
            try
            {
                KeyValuePair<int, Disk> disk = DiskController.GetDisk(id);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
            

        }
    }
}