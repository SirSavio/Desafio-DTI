using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Security;
using Desafio_DTI_CSharp;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Models.DAO;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private Music _music;
        [SetUp]
        public void Inicialize()
        {
            DB.DiskDB = new Dictionary<int, Disk>();
            DB.IndexDisk = 1;
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

            _music = new Music("A","01:20", true);
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
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GetDisk_True(int id)
        {

            DiskController.GetDisk(id);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        public void GetDisk_False(int id)
        {
            try
            {
                KeyValuePair<int, Disk> disk = DiskController.GetDisk(id);
                DiskController.Print(disk.Value);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        public void GetAllDisks_True()
        {
            DiskController.GetAllDisks();
            Assert.Pass();
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void RemoveDisk_True(int id)
        {
            DiskController.RemoveDisk(id);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void RemoveDisk_False(int id)
        {
            try
            {
                DiskController.RemoveDisk(id);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        [TestCase("A")]
        [TestCase("C")]
        [TestCase("F")]
        [TestCase("Other")]
        public void SearchDisk_True(string search)
        {
            DiskController.Search(search);
            Assert.Pass();
        }
        
        [Test]
        [TestCase("")]
        public void SearchDisk_False(string search)
        {
            try
            {
                DiskController.Search(search);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void InsertMusicInDisk_True(int id)
        {
            DiskController.InsertMusic(id, _music);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        public void InsertMusicInDisk_False(int id)
        {
            try
            {
                DiskController.InsertMusic(id, _music);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void GetMusicsInDisk_True(int id)
        {
            DiskController.InsertMusic(id, _music);
            DiskController.GetMusics(id);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        public void GetMusicsInDisk_False(int id)
        {
            try
            {
                DiskController.GetMusics(id);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void GetFavoriteMusicsInDisk_True(int id)
        {
            DiskController.InsertMusic(id, _music);
            DiskController.GetFavoriteMusics(id);
            Assert.Pass();
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(5)]
        public void GetFavoriteMusicsInDisk_False(int id)
        {
            try
            {
                DiskController.GetFavoriteMusics(id);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
    }
}