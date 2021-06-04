using System;
using System.Collections.Generic;
using Desafio_DTI_CSharp;
using Desafio_DTI_CSharp.Controllers;
using Desafio_DTI_CSharp.Models;
using Desafio_DTI_CSharp.Models.DAO;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class TestMusic
    {
        private Disk _disk;
        private Music _music;

        [SetUp]
        public void Inicialize()
        {
            DB.DiskDB = new Dictionary<int, Disk>();
            DB.IndexDisk = 1;
            DB.MusicDB = new Dictionary<int, Music>();
            DB.IndexMusic = 1;

            Disk disk = new Disk("A", "1985", "C");
            DiskController.Create(disk);

            _music = new Music("A", "12:05", true);
            _music.IdDisk = 1;
            DB.MusicDB.Add(1, _music);

            _disk = new Disk("A", "1985", "Name");
        }

        [Test]
        [TestCase("A")]
        [TestCase("C")]
        [TestCase("F")]
        [TestCase("Other")]
        public void SearchMusic_True(string search)
        {
            MusicController.Search(search);
            Assert.Pass();
        }

        [Test]
        [TestCase("")]

        public void SearchMusic_False(string search)
        {
            try
            {
                MusicController.Search(search);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }

            Assert.Fail();
        }

        [Test]
        public void GeneratePlaylist_True()
        {
            MusicController.GeneratePlaylist();
            Assert.Pass();
        }

        [Test]
        [TestCase(1)]
        public void RemoveMusic_True(int id)
        {
            MusicController.RemoveMusic(id);
            Assert.Pass();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        public void RemoveMusic_False(int id)
        {
            try
            {
                MusicController.RemoveMusic(id);
            }
            catch (Exception e)
            {
                Assert.Pass(e.Message);
            }
            Assert.Fail();
        }
    }
}